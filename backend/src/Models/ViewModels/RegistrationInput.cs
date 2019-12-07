using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class RegistrationInputViewModel
    {
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [JsonProperty(Required = Required.DisallowNull)]
        [MinLength(4)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [JsonProperty(Required = Required.DisallowNull)]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        public bool AddCreator { get; set; }
    }
}