using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.chatbot.API.Authentication;
using App.chatbot.API.Models;
using Serilog;

namespace App.chatbot.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        IDatabaseSettings _settings;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ChatBot> Bots { get; set; }
        public DbSet<CreatorUser> Creators { get; set; }

    }
}
