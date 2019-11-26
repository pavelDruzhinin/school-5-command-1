using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using App.chatbot.API.Authentication;
using App.chatbot.API.Data;
using App.chatbot.API.Models;
using App.chatbot.API.Models.ViewModels;

namespace App.chatbot.API.Services
{
    public class ChatBotService
    {
        private ApplicationDbContext _context;

        public ChatBotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ChatBot> FromViewModel(NewChatBotInputViewModel newBot, ApplicationUser creator)
        {
            // Initialize questions
            List<Question> questions = new List<Question>();

            foreach(var q in newBot.Questions)
            {
                questions.Add(new Question { Value = q.Question, Variants = q.Variants });
            }

            // Get creator
            var user = _context.Creators
                        .Where(x => x.Identity.Equals(creator))
                        .First();

            // Make the bot
            return new ChatBot {
                Name = newBot.Name,
                Author = user,
                Questions = questions
            };
        }

        public async Task<ChatBot> GetById(int botId)
        {
            var bot = await _context.Bots.FindAsync(botId);
            return bot;
        }

        public async Task<ChatBot> GetByUrl(string url)
        {
            var bot = _context.Bots
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

        public async Task Delete(int botId)
        {
            var bot = await _context.Bots.FindAsync(botId);
            await Delete(bot);
        }

        public async Task Update(ChatBot bot)
        {
            var result = _context.Bots.Update(bot);
        }

        public async Task Update(int botId, ChatBot bot)
        {
            bot.Id = botId;
            await Update(bot);
        }

    }
}