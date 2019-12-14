using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.chatbot.API.Authentication;

namespace App.chatbot.API.Models
{
    public class ClientUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("Identity")]
        public long IdentityId { get; set; }
        public ApplicationUser Identity { get; set; }  // navigational property

    }
}
