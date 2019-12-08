using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionInputViewModel
    {
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [MinLength(1)]
        public string Text { get; set; }
        
        public JsonDocument Value { get; set; }

        public Question ToQuestion()
        {
            return new Question { Text = Text, Value = Value };
        }
    }
}
