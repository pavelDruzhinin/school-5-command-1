using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using App.chatbot.API.Authentication;

namespace App.chatbot.API.Models
{
    public class ClientUser
    {
        public string Id { get; set; }

        [ForeignKey("Identity")]
        public string IdentityId { get; set; }
        public ApplicationUser Identity { get; set; }  // navigational property

    }
}
