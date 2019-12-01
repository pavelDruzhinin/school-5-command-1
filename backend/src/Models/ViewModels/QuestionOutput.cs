using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Newtonsoft.Json;

namespace App.chatbot.API.Models.ViewModels
{
    public class QuestionOutputViewModel
    {
        public string Question { get; set; }
        
        public object Value { get; set; }

        public QuestionOutputViewModel(Question question)
        {
            var serializer = new JsonSerializer();
            
            Question = question.Text;

            using(var strReader = new StringReader(question.Value))
            using(var jsonReader = new JsonTextReader(strReader))
                Value = serializer.Deserialize<dynamic>(jsonReader);
        }
    }
}
