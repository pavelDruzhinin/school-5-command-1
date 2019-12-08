using System;
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
    public class AnswerService
    {
        private readonly ApplicationDbContext _context;

        public AnswerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(ChatBot bot, ClientUser user, IEnumerable<AnswerInputViewModel> model)
        {
            var answer = new Answer {
                BotId = bot.Id,
                ClientId = user.Id,
                DateAdded = DateTime.Now,
                Answers = model.Select(x => x.Answer).ToList()
            };

            await _context.Answers.AddAsync(answer);
        }

        public async Task<IEnumerable<Answer>> GetForBot(ChatBot bot)
        {
            return await _context.Answers
                    .Include(x => x.Bot)
                    .Include(x => x.Client)
                    .Where(x => x.BotId.Equals(bot.Id))
                    .ToListAsync();
        }

        public async Task<IEnumerable<Answer>> GetForUser(ClientUser user)
        {
            return await _context.Answers
                    .Include(x => x.Bot)
                    .Include(x => x.Client)
                    .Where(x => x.ClientId.Equals(user.Id))
                    .ToListAsync();
        }
    }
}