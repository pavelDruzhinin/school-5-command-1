namespace App.chatbot.API.Helpers
{
    // TODO: generalise this mess
    public class DatabaseSettings : IDatabaseSettings
    {
        private string _Host { get; set; }
        public string Host {
            get { 
                if(string.IsNullOrEmpty(_Host))
                    return "";
                else
                    return $"Host={_Host};";
            }
            set { _Host = value; }
        }
        private string _Database { get; set; }
        public string Database {
            get { 
                if(string.IsNullOrEmpty(_Database))
                    return "";
                else
                    return $"Database={_Database};";
            }
            set { _Database = value; }
        }
        private string _Username { get; set; }
        public string Username {
            get { 
                if(string.IsNullOrEmpty(_Username))
                    return "";
                else
                    return $"Username={_Username};";
            }
            set { _Username = value; }
        }
        private string _Password { get; set; }
        public string Password {
            get { 
                if(string.IsNullOrEmpty(_Password))
                    return "";
                else
                    return $"Password={_Password};";
            }
            set { _Password = value; }
        }
        private string _Port { get; set; }
        public string Port {
            get { 
                if(string.IsNullOrEmpty(_Port))
                    _Port = "5432";
                return $"Port={_Port};";
            }
            set { _Port = value; }
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
        string ConnectionString { get; }
    }
}