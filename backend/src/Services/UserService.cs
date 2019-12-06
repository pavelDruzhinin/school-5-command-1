using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using App.chatbot.API.Authentication;
using App.chatbot.API.Data;
using App.chatbot.API.Models;
using App.chatbot.API.Models.ViewModels;
using Serilog;

namespace App.chatbot.API.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _users;
        private readonly RoleManager<ApplicationRole> _roles;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> users, RoleManager<ApplicationRole> roles, IJwtFactory jwtFactory, JwtIssuerOptions jwtOptions)
        {
            _context = context;
            _users = users;
            _roles = roles;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions;
        }

        
        public async Task<AuthOutputViewModel> GenerateJwt(ClaimsIdentity identity, string UserId)
        {
            return await Tokens.GenerateJwt(identity, _jwtFactory, UserId, _jwtOptions);
        }

        public async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return await Task.FromResult<ClaimsIdentity>(null);

            // get the user to verifty
            var userToVerify = await _users.FindByNameAsync(username);

            if (userToVerify == null) return await Task.FromResult<ClaimsIdentity>(null);

            // check the credentials
            if (await _users.CheckPasswordAsync(userToVerify, password))
            {
                return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(username, userToVerify.Id.ToString()));
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);     
        }

        public async Task<IdentityResult> Register(RegistrationInputViewModel model)
        {
            var userIdentity = new ApplicationUser { UserName = model.Username };

            var result = await _users.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return result;

            await _users.AddToRoleAsync(userIdentity, ApplicationRoles.User);
            await _users.AddToRoleAsync(userIdentity, ApplicationRoles.Creator);

            // Add new user as Creator 
            await _context.Creators.AddAsync(new CreatorUser { IdentityId = userIdentity.Id });
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _users.FindByIdAsync(id);
        }

        public async Task<CreatorUser> GetCreator(ApplicationUser user)
        {
            if(user == null)
                return await Task.FromResult<CreatorUser>(null);

            System.Func<CreatorUser, bool> predicate = (x) => {
                if (x == null) throw new System.NullReferenceException("Creator is null");
                if (x.Identity == null) throw new System.MemberAccessException("Creator is not connected to an identity");
                return x.Identity.Id.Equals(user.Id);
            };

            return _context.Creators
                    .Include(x => x.Identity)
                    .Where(predicate) // x => x.Identity.Id.Equals(user.Id)
                    .First();
        }

        public async Task<bool> HasClaimsTo(CreatorUser user, ChatBot bot)
        {
            if(await _users.IsInRoleAsync(user.Identity, ApplicationRoles.Admin))
                return true;
            
            return user.Id.Equals(bot.AuthorId);
        }
    }
}
