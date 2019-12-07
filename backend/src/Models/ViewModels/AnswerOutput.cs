using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class AnswerOutputViewModel
    {
        public IEnumerable<object> Answer { get; set; }

        public AnswerOutputViewModel(Answer answer)
        {
            Answer = answer.Answers;
        }
    }
}