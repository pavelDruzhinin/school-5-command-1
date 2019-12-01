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

        public string Value { get; set; }

        public string Variants { get; set; }

        // [Column("Variants")]
        // private string _variants { get; set; }


        // [NotMapped]
        // public IEnumerable<String> Variants {
        //     get { return _variants.Split(";"); }
        //     set { _variants = String.Join(";", value); }
        // }

        // [NotMapped]
        // public Boolean HasVariants {
        //     get { return !String.IsNullOrEmpty(_variants); }
        // }
    }
}
