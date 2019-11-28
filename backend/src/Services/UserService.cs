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

namespace App.chatbot.API.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _users;

        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> users)
        {
            _context = context;
            _users = users;
        }

        public async Task<IdentityResult> Register(RegistrationInputViewModel model)
        {
            var userIdentity = new ApplicationUser { UserName = model.Username };

            var result = await _users.CreateAsync(userIdentity, model.Password);

            if (!result.Succeeded) return result;

            // Add new user as Creator 
            await _context.Creators.AddAsync(new CreatorUser { Identity = userIdentity });
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<ApplicationUser> GetUser(ClaimsPrincipal claims)
        {
            return await _users.GetUserAsync(claims);
        }

        public async Task<CreatorUser> GetCreator(ApplicationUser user)
        {
            // System.Func<CreatorUser, bool> predicate = (x) => {
            //     if (x == null) throw new System.NullReferenceException("Creator is null");
            //     if (x.Identity == null) throw new System.MemberAccessException("Creator is not connected to an identity");
            //     return x.Identity.Id == user.Id;
            // };

            return _context.Creators
                    .Include(x => x.Identity)
                        .ThenInclude(i => i.Id)
                    .Where(x => x.Identity.Id.Equals(user.Id))
                    .First();
        }

        public async Task<CreatorUser> GetCreator(ClaimsPrincipal claims)
        {
            var user = await GetUser(claims);
            return await GetCreator(user);
        }
    }
}
