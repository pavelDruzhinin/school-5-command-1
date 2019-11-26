using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.chatbot.API.Models
{
    public class ChatBot
    {
        public int Id { get; set; }
        
        [ForeignKey("QuestionIds")]
        public List<Question> Questions { get; set; } // navigation property

        public CreatorUser Author { get; set; } // navigational property 

        public string Name { get; set; }

        public string Url { get; set; }  // Special url like '/chat/1a2bc34d'

        // public bool Anon { get; set; }  // ���� ���, ����� ��������� ��������� ����� ��������
    }
}