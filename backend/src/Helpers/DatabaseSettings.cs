namespace Services.ChatBot.API.Helpers
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string Hostname { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string ConnectionString { get =>
            $"Host={Hostname};Database={Database};Username={Username};Password={Password}";
        }
    }

    public interface IDatabaseSettings
    {
        string Hostname { get; set; }
        string Database { get; set; }
        string Username { get; set; }
        string Password { get; set; }
    }
}