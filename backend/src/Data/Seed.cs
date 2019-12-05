using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using App.chatbot.API.Authentication;
using App.chatbot.API.Models;
using Serilog;

namespace App.chatbot.API.Data
{
    public static class Seed
    {
        private static bool doneRoles = false;
        public static async Task SeedRoles(IServiceProvider services)
        {
            if(doneRoles) return;
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
            
            Log.Debug("Initializing application roles {@Roles}", ApplicationRoles.Roles);

            foreach (var role in ApplicationRoles.Roles)
            {
                var exists = await roleManager.RoleExistsAsync(role);
                if(!exists)
                {
                    var result = await roleManager.CreateAsync(new ApplicationRole(role));
                }
            }

            doneRoles = true;
        }

        public static async Task SeedAdmin(IServiceProvider services)
        {
            var admin = await SeedUser(services, "admin", "adminpass", ApplicationRoles.Roles);
            await SeedCreator(services, admin); 
        }

        public static async Task<CreatorUser> SeedTestUser(IServiceProvider services)
        {
            var user = await SeedUser(services, "test", "testpass", new string[] { ApplicationRoles.User, ApplicationRoles.Creator });
            return await SeedCreator(services, user); 
        }

        // public static async Task SeedBots(IServiceProvider services)
        // {
        //     var creator = await SeedTestUser(services);


        // }

        private static async Task<CreatorUser> SeedCreator(IServiceProvider services, ApplicationUser user)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            var creator = context.Creators.Where(x => x.IdentityId.Equals(user.Id)).FirstOrDefault();

            if(creator == null)
            {
                var newCreator = new CreatorUser { Identity = user };
                await context.Creators.AddAsync(newCreator);
                await context.SaveChangesAsync();
            }

            return context.Creators.Where(x => x.IdentityId.Equals(user.Id)).FirstOrDefault();
        }

        private static async Task<ApplicationUser> SeedUser(IServiceProvider services, string username, string password, IEnumerable<string> roles)
        {
            await SeedRoles(services);
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();

            var newUser = new ApplicationUser
            {
                UserName = username
            };

            var user = await userManager.FindByNameAsync(username);
            if(user == null)
            {
                var result = await userManager.CreateAsync(newUser);
                if(result.Succeeded)
                {
                    await userManager.AddToRolesAsync(newUser, roles);
                }
            }

            return await userManager.FindByNameAsync(username); 
        }
    }
}