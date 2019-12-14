using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json.Linq;

namespace App.chatbot.API.Models.ViewModels
{
    public class AnswerOutputViewModel
    {
        public dynamic Answer { get; set; }

        public AnswerOutputViewModel(Answer answer)
        {
            Answer = JObject.Parse(answer.Answers);
        }
    }
}