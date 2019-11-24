using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatbot
{
    public class Answers
    {
        int Id { get; set; }
        int IdUser { get; set; }
        int IdQuestion { get; set; }
        string Answer { get; set; }
        DateTime DateBegin { get; set; }
        DateTime DateEnd { get; set; }
    }
}
