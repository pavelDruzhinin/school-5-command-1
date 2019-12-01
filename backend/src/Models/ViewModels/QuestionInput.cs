using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionInputViewModel
    {
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [MinLength(1)]
        public string Question { get; set; }
        
        public List<string> Variants { get; set; }
    }
}
