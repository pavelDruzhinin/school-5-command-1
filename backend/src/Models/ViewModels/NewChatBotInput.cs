using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
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

        public ChatBot ToBot(CreatorUser creator)
        {
            // Initialize questions
            List<Question> questions = new List<Question>();

            foreach(var q in Questions)
            {
                questions.Add(new Question { Text = q.Question, Value = q.SerializedValue() });
            }

            var rng = new Random();
            var url = rng.Next().ToString("x8"); // Will generate hex strings 8 chars in length

            // Make the bot
            return new ChatBot {
                Name = Name,
                AuthorId = creator.Id,
                Questions = questions,
                Url = url
            };
        }
    }
}