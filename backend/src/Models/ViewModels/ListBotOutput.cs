using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using App.chatbot.API.Models;

namespace App.chatbot.API.Models.ViewModels
{
    public class ListBotOutputViewModel
    {
        public string Name { get; set; }
        
        public IEnumerable<QuestionOutputViewModel> Questions { get; set; }

        public ListBotOutputViewModel(ChatBot bot)
        {
            Name = bot.Name;
            Questions = bot.Questions.Select(q => new QuestionOutputViewModel(q));
        }
    }
}