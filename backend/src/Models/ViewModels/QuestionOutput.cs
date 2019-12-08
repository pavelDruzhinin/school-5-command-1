using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionOutputViewModel
    {
        public string Text { get; set; }
        
        public JsonDocument Value { get; set; }

        public QuestionOutputViewModel(Question question)
        {            
            Text = question.Text;
            Value = question.Value;
        }
    }
}
