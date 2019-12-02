using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using App.chatbot.API.Services;
using App.chatbot.API.Authentication;
using App.chatbot.API.Models;
using App.chatbot.API.Models.ViewModels;
using App.chatbot.API.Helpers;
using Serilog;

namespace App.chatbot.API.Controllers
{
    // Adapted from
    // https://fullstackmark.com/post/13/jwt-authentication-with-aspnet-core-2-web-api-angular-5-net-core-identity-and-facebook-login
    [ApiController]
    [Produces("application/json")]
    [Route("api/v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly ChatBotService _bots;
        private readonly UserService _users;

        public AccountsController(ChatBotService bots, UserService users)
        {
            _bots = bots;
            _users = users;
        }

        // POST api/v1/accounts/register
        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Nothing</returns>
        /// <response code="200">Registration successful</response>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Register([FromBody]RegistrationInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _users.Register(model);

            if (!result.Succeeded) return BadRequest(Errors.AddErrorsToModelState(result, ModelState));

            return Ok("Account created");
        }

        // GET api/v1/accounts/current
        /// <summary>
        /// Get additional info about the current user
        /// </summary>
        /// <returns>Current user's username</returns>
        /// <response code="200">Returns the username</response>
        /// <response code="401">User not logged in</response>
        [HttpGet("current")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<string>> Current() // TODO: Output view model
        {
            var user = await GetCurrentUser();
            if(user == null)
                return Unauthorized();
            return await Task.FromResult(user.UserName);
        }

        // GET api/v1/accounts/mybots
        /// <summary>
        /// List chatbots that belong to this user
        /// </summary>
        /// <returns>A list of bots</returns>
        /// <response code="200">My bots</response>
        /// <response code="401">Not logged in</response>
        /// <response code="403">This user can't have bots</response>
        [HttpGet("mybots")]
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