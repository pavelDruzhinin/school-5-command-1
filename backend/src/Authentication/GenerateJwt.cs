using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Newtonsoft.Json;
using App.chatbot.API.Models.ViewModels;

namespace App.chatbot.API.Authentication
{
    public class Tokens
    {
        public static async Task<AuthOutputViewModel> GenerateJwt(ClaimsIdentity identity, IJwtFactory jwtFactory, string UserId, JwtIssuerOptions jwtOptions)
        {
            var response = new AuthOutputViewModel
            {
                Id = identity.Claims.Single(c => c.Type == "id").Value,
                Token = await jwtFactory.GenerateEncodedToken(UserId, identity),
                ExpiresIn = jwtOptions.ValidFor.TotalSeconds.ToString()
            };
            return response;
        }
    }
}