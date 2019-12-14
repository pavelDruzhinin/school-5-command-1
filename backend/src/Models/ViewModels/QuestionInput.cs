using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionInputViewModel
    {
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [MinLength(1)]
        public string Text { get; set; }

                
        public object Value { get; set; }

        public Question ToQuestion()
        {
            return new Question { Text = Text, Value = JsonDocument.Parse(JsonSerializer.Serialize(Value)) };
        }
    }
}
