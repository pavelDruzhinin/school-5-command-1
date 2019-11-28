using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using App.chatbot.API.Authentication;
using App.chatbot.API.Data;
using App.chatbot.API.Services;
using Serilog;

namespace App.chatbot.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddLogging();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // Database settings
            var dbSettings = Configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            Log.Information("Initializing with database settings {@Settings}", dbSettings);
            services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
            services.Configure<DatabaseSettings>(options => options = dbSettings);

            services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(options =>
                options
                    .UseNpgsql(dbSettings.ConnectionString)
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging()
            );

            // Authentication settings
            // Get options from app settings
            var token = Configuration.GetSection(nameof(JwtIssuerOptions)).Get<TokenManager>();
            var _secretKey = Encoding.ASCII.GetBytes(token.Secret);
            // var _secretKey = Encoding.ASCII.GetBytes(Configuration["Auth:SecretKey"]);

            // Configure JwtIssuerOptions
            services.AddSingleton<JwtIssuerOptions>();
            services.Configure<JwtIssuerOptions>(options =>
            {
                options.Issuer = token.Issuer;
                options.Audience = token.Audience;
                options.SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha256);
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.ClaimsIssuer = token.Issuer;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(_secretKey),
                    ValidateIssuer = true,
                    ValidIssuer = token.Issuer,
                    ValidateAudience = true,
                    ValidAudience = token.Audience
                };
            });

            services.AddSingleton<IJwtFactory, JwtFactory>();

            // add Identity
            var builder = services.AddIdentityCore<ApplicationUser>(o =>
            {
                // configure identity options
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
            });
            builder = new IdentityBuilder(builder.UserType, typeof(ApplicationRole), builder.Services);
            builder.AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            services.AddScoped<ChatBotService>();
            services.AddScoped<UserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // loggerFactory.AddSerilog();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseSerilogRequestLogging();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
