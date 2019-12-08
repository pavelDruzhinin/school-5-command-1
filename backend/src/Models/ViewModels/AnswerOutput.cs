using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class AnswerOutputViewModel
    {
        public IEnumerable<JsonDocument> Answer { get; set; }

        public AnswerOutputViewModel(Answer answer)
        {
            Answer = answer.Answers;
        }
    }
}