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
using Microsoft.EntityFrameworkCore;

namespace App.chatbot.API.Data
{
    public static class Seed
    {
        private static bool doneRoles = false;
        public static async Task SeedRoles(IServiceProvider services)
        {
            if (doneRoles) return;
            var roleManager = services.GetRequiredService<RoleManager<ApplicationRole>>();

            Log.Debug("Initializing application roles {@Roles}", ApplicationRoles.Roles);

            foreach (var role in ApplicationRoles.Roles)
            {
                var exists = await roleManager.RoleExistsAsync(role);
                if (!exists)
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

        private static async Task<CreatorUser> SeedCreator(IServiceProvider services, ApplicationUser user)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();

            var creator = context.Creators.Where(x => x.IdentityId.Equals(user.Id)).FirstOrDefault();

            if (creator == null)
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
            if (user == null)
            {
                var result = await userManager.CreateAsync(newUser);
                if (result.Succeeded)
                {
                    await userManager.AddToRolesAsync(newUser, roles);
                }
            }

            return await userManager.FindByNameAsync(username);
        }

        public static async Task SeedBots(IServiceProvider services)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var testcahatbot = await FindChatByNameAndAutorName(services,"test", "chatbot_test1");
            if (testcahatbot == null)
            {

                var listque = new List<Question>();
                    listque.Add(new Question { Text = "Hello." });
                    listque.Add(new Question { Text = "What's your name?" });
                    listque.Add(new Question { Text = "Are you from Petrozavodsk?", Value = "{\"objects\":[{ \"button\":\"Yes\"}, {\"button\":\"No\"}]}" });

                testcahatbot = await SeedBotsForUser(services, "test", "chatbot_test1", listque);
                               
                await context.Bots.AddAsync(testcahatbot);
                await context.SaveChangesAsync();
            }

           testcahatbot = await FindChatByNameAndAutorName(services, "test", "chatbot_test2");
            if (testcahatbot == null)
            {
                var listque = new List<Question>();
                    listque.Add(new Question { Text = "Здравствуйте" , Value = "{ \"button\":\"Hello\" }" });
                    listque.Add(new Question { Text = "Укажите свой возраст", Value = "{\"group\":[{ \"button\":\"менее 18\"}, {\"button\":\"18-30\"},{\"button\":\"31-45\"}, {\"button\":\"более 45\"}]}" });
                    listque.Add(new Question { Text = "Какое у вас образование", Value = "{\"group\":[{\"button\":\"Начальное\"}, {\"button\":\"Сренднее\"},{\"button\":\"Высшее\"}]}" });

                testcahatbot = await SeedBotsForUser(services, "test", "chatbot_test2", listque);

                await context.Bots.AddAsync(testcahatbot);
                await context.SaveChangesAsync();
            }
        }

        private static async Task <ChatBot> FindChatByNameAndAutorName(IServiceProvider services, string authorname, string chatname)
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            var user =  context.Creators
                                .Include(x => x.Identity)
                                .Where(x => x.Identity.UserName.Equals(authorname))
                                .FirstOrDefault();
            if (user == null)
            {
                throw new System.NullReferenceException("Could not find testuser in Database");
            }

            
            var find_chat= context.Bots
                        .Include(x => x.Author)
                        .Include(x => x.Questions)
                        .Where(x => x.Name == chatname)
                        .Where(x => x.AuthorId == user.Id)
                        .FirstOrDefault();
            return find_chat;
        }

        private static async Task <App.chatbot.API.Models.ChatBot> SeedBotsForUser(IServiceProvider services, string username,string _name, List<Question> questions)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var user = await userManager.FindByNameAsync(username);
            if (user==null)
            {
                throw new System.NullReferenceException("Could not find testuser in Database");
            }

             var rng = new Random();

            var testChatbot = new App.chatbot.API.Models.ChatBot()
            {
                Author = await SeedCreator(services, user),
                Name = _name,
                Questions = questions,         
                Url = rng.Next().ToString("x8") // Will generate hex strings 8 chars in length
            };

            return testChatbot;
        }


    }
}