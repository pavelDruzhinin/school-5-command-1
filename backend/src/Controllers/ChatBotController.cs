using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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
        ///         "Name": "Testbot",
        ///         "Questions": [
        ///             { "Question": "Who are you?", "Variants": [] },
        ///             { "Question": "What is your pet?", "Variants": [ "Cat", "Dog" ] }
        ///         ]
        ///     }
        /// 
        /// </remarks>
        /// <param name="newBot"></param>
        /// <returns>Nothing</returns>
        /// <response code="200">New bot is successfully added</response>
        /// <response code="401">Not logged in or this user can't add bots</response>
        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Add(NewChatBotInputViewModel newBot)
        {
            var user = await GetCurrentUser();
            if(user == null)
                return Forbid("Not logged in");
            var creator = await _users.GetCreator(user);
            if(creator == null)
                return Forbid("Not a creator");
            var bot = await ChatBotService.FromViewModel(newBot, creator);
            if(bot == null)
            {
                throw new System.NullReferenceException("Could not create a new bot");
            }
            await _bots.Create(bot);
            return CreatedAtRoute(
                routeName: "GetByUrl",
                routeValues: new { url = bot.Url },
                value: new BotOutputViewModel(bot)
            );
        }

        // GET api/v1/chatbot/[url]
        /// <summary>
        /// Access a chat bot by its unique url
        /// </summary>
        /// <param name="url"></param>
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

        // GET api/v1/chatbot/my
        /// <summary>
        /// List chatbots that belong to this user
        /// </summary>
        /// <returns>A list of bots</returns>
        /// <response code="200">My bots</response>
        /// <response code="401">Not logged in or this user can't have bots</response>
        [HttpGet("my")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ListBotOutputViewModel>> GetMine()
        {
            var user = await GetCurrentUser();
            if(user == null)
                return Forbid("Not logged in");
            var creator = await _users.GetCreator(user);
            if(creator == null)
                return Forbid("Not a creator");
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