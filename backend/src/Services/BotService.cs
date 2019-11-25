using System.Threading.Tasks;
using System.Linq;
using App.chatbot.API.Data;
using App.chatbot.API.Models;

namespace App.chatbot.API.Services
{
    public class ChatBotService
    {
        private ApplicationDbContext _context;

        public ChatBotService(ApplicationDbContext context)
        {
            _context = context;
        }

        async Task<ChatBot> GetById(int botId)
        {
            var bot = await _context.Bots.FindAsync(botId);
            return bot;
        }

        async Task<ChatBot> GetByUrl(string url)
        {
            var bot = _context.Bots
                        .Where(x => x.Url == url)
                        .First();
            return bot;
        }

        async Task Create(ChatBot bot)
        {
            var result = await _context.Bots.AddAsync(bot);
        }

        async Task Delete(ChatBot bot)
        {
            _context.Bots.Remove(bot);
        }

        async Task Delete(int botId)
        {
            var bot = await _context.Bots.FindAsync(botId);
            await Delete(bot);
        }

        async Task Update(ChatBot bot)
        {
            var result = _context.Bots.Update(bot);
        }

        async Task Update(int botId, ChatBot bot)
        {
            bot.Id = botId;
            await Update(bot);
        }

    }
}