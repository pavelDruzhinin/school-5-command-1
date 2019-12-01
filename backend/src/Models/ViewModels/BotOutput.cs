using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using App.chatbot.API.Models;

namespace App.chatbot.API.Models.ViewModels
{
    public class BotOutputViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }
        
        public IEnumerable<QuestionOutputViewModel> Questions { get; set; }

        public BotOutputViewModel(ChatBot bot)
        {
            Name = bot.Name;
            Url = bot.Url;
            Questions = bot.Questions?.Select(q => new QuestionOutputViewModel(q));
        }
    }
}