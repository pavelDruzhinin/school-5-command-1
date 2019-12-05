using Microsoft.AspNetCore.Identity;

namespace App.chatbot.API.Authentication
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() : base()
        { }

        public ApplicationRole(string roleName) : base(roleName)
        { }
    }

    public static class ApplicationRoles
    {
        public static readonly string[] Roles = new string[] { User, Creator, Admin };

        public const string User = "User";
        public const string Creator = "Creator";
        public const string Admin = "Admin";
    }
}
