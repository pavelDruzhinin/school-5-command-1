using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionInputViewModel
    {
        [Required(AllowEmptyStrings=false)]
        [DisplayFormat(ConvertEmptyStringToNull=false)]
        [MinLength(1)]
        public string Question { get; set; }
        
        public object Value { get; set; }

        public string SerializedValue()
        {
            var serializer = new JsonSerializer();
            var strWriter = new StringWriter();
            
            serializer.Serialize(strWriter, Value);

            return strWriter.ToString();
        }
    }
}
