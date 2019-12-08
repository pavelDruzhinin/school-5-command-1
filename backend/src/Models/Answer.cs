using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.chatbot.API.Models
{
    // Ответ пользователя на бота
    // Соединяет пользователя и бота, даёт список ответов-стрингов
    // Может быть анонимным либо нет (UserId = null)
    public class Answer
    {
        public string Id { get; set; }

        [ForeignKey("Bot")]
        public string BotId { get; set; }
        public ChatBot Bot { get; set; } // navigational property 

        [ForeignKey("Client")]
        public string ClientId { get; set; }
        public ClientUser Client { get; set; } // navigational property 

        [Column(TypeName="jsonb[]")]
        public List<JsonDocument> Answers { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
