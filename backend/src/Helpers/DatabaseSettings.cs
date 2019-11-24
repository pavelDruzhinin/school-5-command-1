namespace Services.ChatBot.API.Helpers
{
    // TODO: generalise this mess
    public class DatabaseSettings : IDatabaseSettings
    {
        public string Host {
            get { 
                if(string.IsNullOrEmpty(Host))
                    return "";
                else
                    return $"Host={Host};";
            }
            set { Host = value; }
        }
        public string Database {
            get { 
                if(string.IsNullOrEmpty(Database))
                    return "";
                else
                    return $"Database={Database};";
            }
            set { Database = value; }
        }
        public string Username {
            get { 
                if(string.IsNullOrEmpty(Username))
                    return "";
                else
                    return $"Username={Username};";
            }
            set { Username = value; }
        }
        public string Password {
            get { 
                if(string.IsNullOrEmpty(Password))
                    return "";
                else
                    return $"Password={Password};";
            }
            set { Password = value; }
        }
        public string Port {
            get { 
                if(string.IsNullOrEmpty(Port))
                    return "Port=5432;";
                else
                    return $"Port={Port};";
            }
            set { Port = value; }
        }

        public string ConnectionString { get =>
            $"{Host}{Port}{Username}{Password}{Database}";
        }
    }

    public interface IDatabaseSettings
    {
        string Host { get; set; }
        string Database { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Port { get; set; }
    }
}