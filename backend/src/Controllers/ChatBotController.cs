using System.Collections.Generic;
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
        public async Task<IActionResult> Add(NewChatBotInputViewModel newBot)
        {
            var usr = await GetCurrentUser();
            var user = await _users.GetCreator(usr);
            if(user == null)
            {
                return Forbid();
            }
            var bot = await ChatBotService.FromViewModel(newBot, user);
            if(bot == null)
            {
                throw new System.NullReferenceException("Could not create a new bot");
            }
            await _bots.Create(bot);
            return Ok();
        }

        [HttpGet("listmine")]
        public async Task<IEnumerable<ListBotOutputViewModel>> GetMine()
        {
            var user = await GetCurrentUser();
            var creator = await _users.GetCreator(user);
            var bots = await _bots.GetForUser(creator);
            var output = bots.Select(b => new ListBotOutputViewModel(b));
            return output;
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