using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using App.chatbot.API.Models;

namespace App.chatbot.API.Models.ViewModels
{
    public class ListBotOutputViewModel
    {        
        public IEnumerable<BotOutputViewModel> Bots { get; set; }
    }
}