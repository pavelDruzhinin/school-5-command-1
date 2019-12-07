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
        // GET /api/v1/chatbot/{url:8}/questions/all
        /// <summary>
        /// Get all questions from a bot
        /// </summary>
        /// <param name="url">Bot's unique url</param>
        /// <returns>A question</returns>
        /// <response code="200"></response>
        /// <response code="404">This bot does not exist</response>
        [AllowAnonymous]
        [HttpGet("{url:length(8)}/questions/all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<QuestionOutputViewModel>>> GetAllQuestions([FromRoute] string url)
        {
            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();

            var output = bot.Questions.Select(q => new QuestionOutputViewModel(q));
            return Ok(output);
        }

        // GET /api/v1/chatbot/{url:8}/questions/{index:int}
        /// <summary>
        /// Get a specified question from a bot
        /// </summary>
        /// <param name="url">Bot's unique url</param>
        /// <param name="index">Question number starting from 0</param>
        /// <returns>A question</returns>
        /// <response code="200"></response>
        /// <response code="404">This bot does not exist</response>
        /// <response code="400">Index out of range</response>
        [AllowAnonymous]
        [HttpGet("{url:length(8)}/questions/{index:int}", Name = "GetQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<QuestionOutputViewModel>> GetQuestion([FromRoute] string url, [FromRoute] int index)
        {
            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();

            if(index >= bot.Questions.Count()) return BadRequest();

            var output = new QuestionOutputViewModel(bot.Questions[index]);
            return Ok(output);
        }

        // POST /api/v1/chatbot/{url:8}/questions/add?index={i}
        /// <summary>
        /// Insert a new question
        /// </summary>
        /// <param name="url">Bot's unique url</param>
        /// <param name="index">Index at which to insert</param>
        /// <param name="question">New question</param>
        /// <returns></returns>
        /// <response code="200">Added successfully</response>
        /// <response code="403">This bot does not belong to you</response>
        /// <response code="404">This bot does not exist</response>
        /// <response code="400">Index out of range</response>
        [HttpPost("{url:length(8)}/questions/add")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> InsertQuestion([FromRoute] string url, [FromQuery] int index, [FromBody] QuestionInputViewModel question)
        {
            var user = await GetCurrentUser();
            if(user == null) return Unauthorized();

            var creator = await _users.GetCreator(user);
            if(creator == null) return Forbid();

            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();
            if(!await _users.HasClaimsTo(creator, bot)) return Forbid();

            if(index > bot.Questions.Count()) return BadRequest();

            var q = question.ToQuestion();

            await _bots.InsertQuestion(bot, q, index);
            await _bots.SaveChanges();
            return CreatedAtRoute(
                routeName: "GetQuestion",
                routeValues: new { url = bot.Url, index = index },
                value: new QuestionOutputViewModel(q)
            );
        }

        // DELETE /api/v1/chatbot/{url:8}/questions/{index:int}
        /// <summary>
        /// Deletes a question in the bot
        /// </summary>
        /// <param name="url">Bot's unique url</param>
        /// <param name="index">Index of the question to delete</param>
        /// <returns></returns>
        /// <response code="200">Deleted successfully</response>
        /// <response code="403">This bot does not belong to you</response>
        /// <response code="404">This bot does not exist</response>
        /// <response code="400">Index out of range</response>
        [HttpDelete("{url:length(8)}/questions/{index:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteQuestion([FromRoute] string url, [FromQuery] int index)
        {
            var user = await GetCurrentUser();
            if(user == null) return Unauthorized();

            var creator = await _users.GetCreator(user);
            if(creator == null) return Forbid();

            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();
            if(!await _users.HasClaimsTo(creator, bot)) return Forbid();

            if(index >= bot.Questions.Count()) return BadRequest();

            await _bots.DeleteQuestion(bot, index);
            await _bots.SaveChanges();
            return Ok();
        }

        // Patch /api/v1/chatbot/{url:8}/questions/{index:int}
        /// <summary>
        /// Edits a question in the bot
        /// </summary>
        /// <param name="url">Bot's unique url</param>
        /// <param name="index">Index of the question to delete</param>
        /// <param name="patch">Patch for the question</param>
        /// <returns></returns>
        /// <response code="200">Patched successfully</response>
        /// <response code="403">This bot does not belong to you</response>
        /// <response code="404">This bot does not exist</response>
        /// <response code="400">Index out of range</response>
        [HttpPatch("{url:length(8)}/questions/{index:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchQuestion([FromRoute] string url, [FromQuery] int index, [FromBody] QuestionPatchViewModel patch)
        {
            var user = await GetCurrentUser();
            if(user == null) return Unauthorized();

            var creator = await _users.GetCreator(user);
            if(creator == null) return Forbid();

            var bot = await _bots.GetByUrl(url);
            if(bot == null) return NotFound();
            if(!await _users.HasClaimsTo(creator, bot)) return Forbid();

            if(index >= bot.Questions.Count()) return BadRequest();

            var question = bot.Questions[index];
            patch.Patch(ref question);
            await _bots.UpdateQuestion(bot, index, question);
            await _bots.SaveChanges();
            return Ok();
        }

        
    }
}