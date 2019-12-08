using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class AccountInfoOutputViewModel
    {
        public string Username { get; set; }

        [JsonProperty("my_bots")]
        public IEnumerable<string> MyBots { get; set; }

        [JsonProperty("answered_bots")]
        public IEnumerable<string> AnsweredBots { get; set; }
    }
}