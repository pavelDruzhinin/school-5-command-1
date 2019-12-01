using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using App.chatbot.API.Authentication;
using App.chatbot.API.Data;

namespace App.chatbot.API.Models.ViewModels
{
    public class NewChatBotInputViewModel
    {
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        public string Name { get; set; }
        
        [Required]
        [MinLength(1)]
        public IEnumerable<QuestionInputViewModel> Questions { get; set; }
    }
}