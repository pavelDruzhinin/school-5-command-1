using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionInputViewModel
    {
        [Required]
        public string Question { get; set; }
        
        public IEnumerable<string> Variants { get; set; }
    }
}
