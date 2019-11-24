using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace chatbot
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Answers> Answers { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Chats> Chats { get; set; }

    }
}
