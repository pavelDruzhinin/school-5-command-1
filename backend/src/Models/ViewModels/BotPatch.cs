using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using App.chatbot.API.Authentication;
using App.chatbot.API.Data;

namespace App.chatbot.API.Models.ViewModels
{
    public class ChatBotPatchViewModel
    {
        public string Name { get; set; }
        
        public IEnumerable<QuestionInputViewModel> Questions { get; set; }

        public void Patch(ref ChatBot bot)
        {
            if(Name != null)
            {
                bot.Name = Name;
            }
            
            if(Questions != null)
            {
                bot.Questions.Clear();
                foreach(var q in Questions)
                {
                    bot.Questions.Add(new Question { Text = q.Text, Value = q.SerializedValue() });
                }
            }
        }
    }
}