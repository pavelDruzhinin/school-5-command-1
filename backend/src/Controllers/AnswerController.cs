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
    public partial class ChatBotController : ControllerBase
    {
        [HttpPost("{url:length(8)}/answer")]
        public async Task<IActionResult> AddAnswer( [FromRoute] string url, [FromBody] IEnumerable<AnswerInputViewModel> answerModel)
        {
            var user = await GetCurrentUser();
            if(user == null) return Unauthorized();

            var client = await _users.GetClient(user);
            if(client == null) return Forbid();

            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();

            await _answers.Add(bot, client, answerModel);
            await _bots.SaveChanges();

            return Ok();
        }

        [HttpGet("{url:length(8)}/answers")]
        public async Task<ActionResult<IEnumerable<AnswerOutputViewModel>>> GetAnswers( [FromRoute] string url)
        {
            var user = await GetCurrentUser();
            if(user == null) return Unauthorized();

            var creator = await _users.GetCreator(user);
            if(creator == null) return Forbid();

            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();
            if(!await _users.HasClaimsTo(creator, bot)) return Forbid();

            var answers = await _answers.GetForBot(bot);
            var output = answers.Select(x => new AnswerOutputViewModel(x));

            return Ok(output);
        }
    }
}