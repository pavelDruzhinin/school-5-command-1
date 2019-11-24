using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatbot
{
    public class Chats
    {
        int Id { get; set; }
        int IdAuthor { get; set; }
        string ChatName { get; set; }
        DateTime DateAdd { get; set; }
        bool Anon { get; set; }
    }
}
