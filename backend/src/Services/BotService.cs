using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using App.chatbot.API.Data;
using App.chatbot.API.Models;
using App.chatbot.API.Models.ViewModels;

namespace App.chatbot.API.Services
{
    public class ChatBotService
    {
        private readonly ApplicationDbContext _context;

        public ChatBotService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<ChatBot>> GetForUser(CreatorUser creator)
        {
            return await _context.Bots
                .Include(x => x.Author)
                .Include(x => x.Questions)
                .Where(x => x.Author.Id == creator.Id)
                .ToListAsync();
        }

        public async Task<ChatBot> GetById(string botId)
        {
            var bot = await _context.Bots.FindAsync(botId);
            return bot;
        }

        public async Task<ChatBot> GetByUrl(string url)
        {
            var bot = _context.Bots
                        .Include(x => x.Author)
                        .Include(x => x.Questions)
                        .Where(x => x.Url == url)
                        .First();
            return bot;
        }

        public async Task Create(ChatBot bot)
        {
            var result = await _context.Bots.AddAsync(bot);
        }

        public async Task Delete(ChatBot bot)
        {
            _context.Bots.Remove(bot);
        }

        public async Task Delete(string botId)
        {
            var bot = await _context.Bots.FindAsync(botId);
            await Delete(bot);
        }

        public async Task Update(ChatBot bot)
        {
            var result = _context.Bots.Update(bot);
        }

        public async Task Update(string botId, ChatBot bot)
        {
            bot.Id = botId;
            await Update(bot);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}