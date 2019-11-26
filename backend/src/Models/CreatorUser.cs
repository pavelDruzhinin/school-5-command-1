using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using App.chatbot.API.Authentication;

namespace App.chatbot.API.Models
{
    public class CreatorUser
    {
        public int Id { get; set; }

        [ForeignKey("IdentityId")]
        public ApplicationUser Identity { get; set; }  // navigational property

        [ForeignKey("BotIds")]
        public List<ChatBot> Bots { get; set; }  // navigational property

    }
}
