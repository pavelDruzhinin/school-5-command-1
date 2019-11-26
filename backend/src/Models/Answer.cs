using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.chatbot.API.Models
{
    // Ответ пользователя на бота
    // Соединяет пользователя и бота, даёт список ответов-стрингов
    // Может быть анонимным либо нет (UserId = null)
    public class Answer
    {
        public int Id { get; set; }

        // [ForeignKey("UserId")]
        // public GuestUser User { get; set; } // navigational property 

        [ForeignKey("BotId")]
        public ChatBot Bot { get; set; } // navigational property 

        public List<string> Answers { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
