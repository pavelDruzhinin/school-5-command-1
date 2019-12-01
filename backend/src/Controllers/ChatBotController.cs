using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using App.chatbot.API.Authentication;
using App.chatbot.API.Services;
using App.chatbot.API.Models;
using App.chatbot.API.Models.ViewModels;
using Serilog;

namespace App.chatbot.API.Controllers
{
    [ApiController]
    [Authorize(Policy = "ApiUser")]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly ChatBotService _bots;
        private readonly UserService _users;

        public ChatBotController(ChatBotService bots, UserService users)
        {
            _bots = bots;
            _users = users;
        }

        // POST api/v1/chatbot/add
        /// <summary>
        /// Add a new chat bot belonging to current user
        /// </summary>
        /// <remarks>
        /// Sample request 
        /// 
        ///     POST /api/v1/chatbot/add
        ///     {
        ///     	"Name": "Newbot",
	    ///         "Questions": [
		///             { "Question": "What", "Value": { "type": "any" } },
        ///             { "Question": "Which", "Value": { "variants": ["Cat", "Dog"] } }
	    ///         ]
        ///     }
        /// 
        /// </remarks>
        /// <param name="newBot"></param>
        /// <returns>Nothing</returns>
        /// <response code="201">New bot is successfully created</response>
        /// <response code="403">Not logged in or this user can't add bots</response>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Add(NewChatBotInputViewModel newBot)
        {
            var user = await GetCurrentUser();
            if(user == null)
                return Unauthorized();
            var creator = await _users.GetCreator(user);
            if(creator == null)
                return Forbid();
            var bot = newBot.ToBot(creator);
            if(bot == null)
            {
                throw new System.NullReferenceException("Could not create a new bot");
            }
            await _bots.Create(bot);
            await _bots.SaveChanges();
            return CreatedAtRoute(
                routeName: "GetByUrl",
                routeValues: new { url = bot.Url },
                value: new BotOutputViewModel(bot)
            );
        }

        // GET api/v1/chatbot/{url:8}
        /// <summary>
        /// Access a chat bot by its unique url
        /// </summary>
        /// <param name="url">Unique bot URL</param>
        /// <returns>A chat bot instance</returns>
        /// <response code="200">The requested chat bot</response>
        /// <response code="404">Bot withthis url is not found</response>
        [HttpGet("{url:length(8)}", Name = "GetByUrl")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BotOutputViewModel>> GetByUrl( [FromRoute] string url )
        {
            var bot = await _bots.GetByUrl(url);
            if(bot == null)
                return NotFound();
            return Ok(new BotOutputViewModel(bot));
        }

        // PATCH api/v1/chatbot/{url}:8}
        /// <summary>
        /// Patch your bot
        /// </summary>
        /// <param name="url">Bot's unique URL</param>
        /// <param name="patch">Patch to apply</param>
        /// <returns>Nothing</returns>
        /// <response code="200">Patched successfully</response>
        /// <response code="403">This bot does not belong to you</response>
        /// <response code="404">This bot does not exist</response>
        [HttpPatch("{url:length(8)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchBot( [FromRoute] string url, [FromBody] ChatBotPatchViewModel patch)
        {
            var user = await GetCurrentUser();
            if(user == null) return Unauthorized();

            var creator = await _users.GetCreator(user);
            if(creator == null) return Forbid();

            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();
            if(bot.AuthorId != creator.Id) return Forbid();

            patch.Patch(ref bot);
            await _bots.Update(bot);
            await _bots.SaveChanges();

            return Ok();
        }

        // DELETE api/v1/chatbot/{url:8}
        /// <summary>
        /// Delete your bot (dangerous)
        /// </summary>
        /// <param name="url">Bot's unique URL</param>
        /// <returns>Nothing</returns>
        /// <response code="200">Deleted successfully</response>
        /// <response code="403">This bot does not belong to you</response>
        /// <response code="404">This bot does not exist</response>
        [HttpDelete("{url:length(8)}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteBot( [FromRoute] string url )
        {
            var user = await GetCurrentUser();
            if(user == null) return Unauthorized();

            var creator = await _users.GetCreator(user);
            if(creator == null) return Forbid();

            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();
            if(bot.AuthorId != creator.Id) return Forbid();

            await _bots.Delete(bot);
            await _bots.SaveChanges();
            return Ok();
        }

        // GET api/v1/chatbot/my
        /// <summary>
        /// List chatbots that belong to this user
        /// </summary>
        /// <returns>A list of bots</returns>
        /// <response code="200">My bots</response>
        /// <response code="403">Not logged in or this user can't have bots</response>
        [HttpGet("my")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<ListBotOutputViewModel>> GetMine()
        {
            var user = await GetCurrentUser();
            if(user == null)
                return Unauthorized();
            var creator = await _users.GetCreator(user);
            if(creator == null)
                return Forbid();
            var bots = await _bots.GetForUser(creator);
            var botsView = bots.Select(b => new BotOutputViewModel(b));
            var output = new ListBotOutputViewModel { Bots = botsView };
            return Ok(output);
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            var claim = HttpContext.User;
            if(claim == null) return await Task.FromResult<ApplicationUser>(null);
            var id = HttpContext.User.Claims.FirstOrDefault(c => {
                return c.Type == "id";
            })?.Value;
            if(id == null) return await Task.FromResult<ApplicationUser>(null);
            return await _users.GetUserById(id);
        }
    }
}