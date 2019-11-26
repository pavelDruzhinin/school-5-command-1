using System.Threading.Tasks;
using System.Security.Claims;
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
    [Authorize]
    [Route("api/v1/[controller]")]
    public class ChatBotController : ControllerBase
    {
        private readonly ChatBotService _bots;
        private readonly UserManager<ApplicationUser> _userManager;

        public ChatBotController(ChatBotService bots, UserManager<ApplicationUser> userManager)
        {
            _bots = bots;
            _userManager = userManager;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(NewChatBotInputViewModel newBot)
        {
            var user = await _userManager.GetUserAsync(User);
            var bot = await _bots.FromViewModel(newBot, user);
            await _bots.Create(bot);
            return Ok();
        }
    }
}