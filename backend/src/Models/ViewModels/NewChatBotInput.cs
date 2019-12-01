using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using App.chatbot.API.Authentication;
using App.chatbot.API.Data;

namespace App.chatbot.API.Models.ViewModels
{
    public class NewChatBotInputViewModel
    {
        public string Name { get; set; }
        
        public IEnumerable<QuestionInputViewModel> Questions { get; set; }
    }
}