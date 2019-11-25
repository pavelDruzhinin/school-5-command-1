using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Services.ChatBot.API.Models
{

    public class Answer
    {
        public int Id { get; set; }

        public int? AuthorId { get; set; }

        [ForeignKey("BotId")]
        public ChatBot Bot { get; set; } // navigational property 

        public IEnumerable<string> Answers { get; set; }

        public DateTime DateAdded { get; set; }
        
        
    }
}
