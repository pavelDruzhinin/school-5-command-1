using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class AnswerInputViewModel
    {
        [Required]
        public object Answer { get; set; }

        public string SerializedValue()
        {
            var serializer = new JsonSerializer();
            var strWriter = new StringWriter();
            
            serializer.Serialize(strWriter, Answer);

            return strWriter.ToString();
        }
    }
}