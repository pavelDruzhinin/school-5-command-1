using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.chatbot.API.Models
{
    // Вопрос состоит из самого вопроса, и возможных ответов к нему
    // Ответы - строка разделённая ";"
    //          либо пустая строка - свободный ответ
    public class Question
    {
        public string Id { get; set; }

        [ForeignKey("Bot")]
        public string BotId { get; set; }
        public ChatBot Bot { get; set; } // navigational property

        public string Text { get; set; }

        [Column(TypeName = "jsonb")]
        public string Value { get; set; }
    }
}
