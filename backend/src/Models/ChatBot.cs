using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ChatBot.API.Models
{
    public class ChatBot
    {
        public int Id { get; set; }
        
        [ForeignKey("QuestionIds")]
        public IEnumerable<Question> Questions { get; set; } // navigation property

        public string Url { get; set; }  // Special url like '/chat/1a2bc34d'

        public bool Anon { get; set; } //Можно ли юзать чат анонимным пользователям
    }
}