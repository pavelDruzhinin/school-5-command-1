using System;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace App.chatbot.API.Authentication
{
    public class JwtIssuerOptions
    {
        //Borrowed from: https://github.com/mmacneil/AngularASPNETCore2WebApiAuth/blob/master/src/Models/JwtIssuerOptions.cs
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Audience { get; set; }
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public DateTime NotBefore { get; set; } = DateTime.UtcNow;
        public DateTime IssuedAt { get; set; } = DateTime.UtcNow;
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromDays(1);
        public bool RequireHttpsMetadata { get; set; } = true;
        public Func<Task<string>> JtiGenerator =>
            () => Task.FromResult(Guid.NewGuid().ToString());
        public SigningCredentials SigningCredentials { get; set; }
    }
}