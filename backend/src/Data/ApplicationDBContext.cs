using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.ChatBot.API.Models;

namespace Services.ChatBot.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Services.ChatBot.API.Models.ChatBot> Bots { get; set; }  // Из-за того что просто ChatBot это namespace надо использовать fully qualified 

    }
}
