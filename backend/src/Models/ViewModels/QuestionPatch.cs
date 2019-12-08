using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionPatchViewModel
    {
        public string Text { get; set; }
        
        public JsonDocument Value { get; set; }

        public void Patch(ref Question question)
        {
            if(Text != null)
            {
                question.Text = Text;
            }

            if(Value != null)
            {
                question.Value = Value;
            }
        }
    }
}
