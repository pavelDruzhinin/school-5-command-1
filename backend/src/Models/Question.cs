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
        public int Id { get; set; }

        public ChatBot Bot { get; set; } // navigational property

        public String Value { get; set; }

        private String _variants { get; set; }


        [NotMapped]
        public IEnumerable<String> Variants {
            get { return _variants.Split(";"); }
            set { _variants = String.Join(";", value); }
        }

        [NotMapped]
        public Boolean HasVariants {
            get { return !String.IsNullOrEmpty(_variants); }
        }
    }
}
