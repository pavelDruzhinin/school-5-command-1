using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.chatbot.API.Helpers;
using App.chatbot.API.Models;
using Serilog;

namespace App.chatbot.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        IDatabaseSettings _settings;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDatabaseSettings databaseSettings) : base(options)
        {
            Log.Information("Initializing with database settings {@Settings}", databaseSettings);
            _settings = databaseSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_settings.ConnectionString);
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ChatBot> Bots { get; set; }  // Из-за того что просто ChatBot это namespace надо использовать fully qualified 

    }
}
