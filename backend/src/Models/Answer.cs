using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ChatBot.API.Models
{
    // Ответ пользователя на бота
    // Соединяет пользователя и бота, даёт список ответов-стрингов
    // Может быть анонимным либо нет
    // (надо ли bool если можно AuthorId = null ?)
    public class Answer
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("BotId")]
        public ChatBot Bot { get; set; } // navigational property 

        public IEnumerable<string> Answers { get; set; }

        public DateTime DateAdded { get; set; }
        
        
    }
}
