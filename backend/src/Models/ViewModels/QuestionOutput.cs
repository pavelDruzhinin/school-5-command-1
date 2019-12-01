using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionOutputViewModel
    {
        public string Question { get; set; }
        
        public IEnumerable<string> Variants { get; set; }

        public QuestionOutputViewModel(Question question)
        {
            Question = question.Value;
            if(string.IsNullOrEmpty(question.Variants))
                Variants = null;
            else
                Variants = question.Variants.Split(";");
        }
    }
}
