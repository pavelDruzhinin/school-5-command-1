using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class AnswerInputViewModel
    {
        [Required]
        public JsonDocument Answer { get; set; }
    }
}