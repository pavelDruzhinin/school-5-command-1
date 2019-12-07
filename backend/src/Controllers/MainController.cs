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
    public partial class ChatBotController : ControllerBase
    {
        private readonly ChatBotService _bots;
        private readonly UserService _users;
        private readonly AnswerService _answers;

        public ChatBotController(ChatBotService bots, UserService users, AnswerService answers)
        {
            _bots = bots;
            _users = users;
            _answers = answers;
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