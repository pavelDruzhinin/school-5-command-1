using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.chatbot.API.Models
{
    // Вопрос состоит из самого вопроса, и возможных ответов к нему
    // Ответы - строка разделённая ";"
    //          либо пустая строка - свободный ответ
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Bot")]
        public long BotId { get; set; }
        public ChatBot Bot { get; set; } // navigational property

        public string Text { get; set; }

        [Column(TypeName="jsonb")]
        public JsonDocument Value { get; set; }
    }
}
