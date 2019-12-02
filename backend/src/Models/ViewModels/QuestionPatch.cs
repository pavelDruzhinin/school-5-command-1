using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionPatchViewModel
    {
        public string Text { get; set; }
        
        public object Value { get; set; }

        public void Patch(ref Question question)
        {
            if(Text != null)
            {
                question.Text = Text;
            }

            if(Value != null)
            {
                question.Value = SerializedValue();
            }
        }

        public string SerializedValue()
        {
            var serializer = new JsonSerializer();
            var strWriter = new StringWriter();
            
            serializer.Serialize(strWriter, Value);

            return strWriter.ToString();
        }
    }
}
