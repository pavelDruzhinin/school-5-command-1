using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using App.chatbot.API.Services;
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
    public class AuthController : ControllerBase
    {
        private readonly UserService _users;

        public AuthController(UserService users)
        {
            _users = users;
        }

        // POST api/v1/auth/login
        /// <summary>
        /// Authenticate with plain username and password
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns>A JWT token</returns>
        /// <response code="200">Authorization successful</response>
        /// <response code="401">Bad username or password</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<AuthOutputViewModel>> Login([FromBody]CredentialsInputViewModel credentials)
        {
            var identity = await _users.GetClaimsIdentity(credentials.Username, credentials.Password);
            if (identity == null)
            {
                return Forbid();
            }

            var userid = identity.FindFirst(c => c.Type == Constants.Strings.JwtClaimIdentifiers.Id).Value;

            var jwt = await _users.GenerateJwt(identity, userid);
            return Ok(jwt);
        }
        
    }
}