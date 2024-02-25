namespace barber.Data.Models
{
    public class ConnectionOptions
    {
        public ConnectionOptions(string serverName, string databaseName, string? userName, string? password)
        {
            ServerName = serverName;
            DatabaseName = databaseName;
            UserName = userName;
            Password = password;
        }

        public string DatabaseName { get; }

        public string? Password { get; }

        public string ServerName { get; }

        public string? UserName { get; }
    }
}