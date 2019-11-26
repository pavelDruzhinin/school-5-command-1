using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.chatbot.API.Models.ViewModels
{
    public class CredentialsInputViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}