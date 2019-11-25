using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.ChatBot.API.Helpers;
using Services.ChatBot.API.Models;
using Serilog;

namespace Services.ChatBot.API.Data
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
        public DbSet<Services.ChatBot.API.Models.ChatBot> Bots { get; set; }  // Из-за того что просто ChatBot это namespace надо использовать fully qualified 

    }
}
