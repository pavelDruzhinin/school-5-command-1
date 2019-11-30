using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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

        [HttpPost("add")]
        [Authorize]
        public async Task<IActionResult> Add(NewChatBotInputViewModel newBot)
        {
            var usr = await GetCurrentUser();
            var user = await _users.GetCreator(usr);
            if(user == null)
            {
                return Forbid();
            }
            var bot = await _bots.FromViewModel(newBot, user);
            if(bot == null)
            {
                throw new System.NullReferenceException("Could not create a new bot");
            }
            await _bots.Create(bot);
            return Ok();
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            var claim = HttpContext.User;
            var id = HttpContext.User.Claims.First(c => {
                Log.Verbose("Claim type {@claim}", c.Type);
                return c.Type == "id";
            }).Value;
            return await _users.GetUserById(id);
        }
    }
}