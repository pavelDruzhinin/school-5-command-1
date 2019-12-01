using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
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
    [Route("api/v1/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly UserService _users;

        public AccountsController(UserService users)
        {
            _users = users;
        }

        // POST api/v1/accounts/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegistrationInputViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _users.Register(model);

            if (!result.Succeeded) return new BadRequestObjectResult(Errors.AddErrorsToModelState(result, ModelState));

            return new OkObjectResult("Account created");
        }

        [HttpGet("current")]
        public async Task<string> Current() // TODO: Output view model
        {
            var user = await GetCurrentUser();
            return await Task.FromResult(user.UserName);
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