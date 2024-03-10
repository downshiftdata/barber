namespace barber.Data.Models
{
    public class DatabaseRequest : IRequestModel
    {
        public DatabaseRequest() { }

        public DatabaseRequest(DatabaseResponse response)
        {
            DatabaseKey = response.DatabaseKey;
            EnvironmentType = response.EnvironmentType;
            ServerName = response.ServerName;
            DatabaseName = response.DatabaseName;
            AuthenticationType = response.AuthenticationType;
            UserName = response.UserName;
            PasswordHash = response.PasswordHash;
            Description = response.Description;
        }

        public Enum.AuthenticationType AuthenticationType { get; set; } = Enum.AuthenticationType.None;

        public long? DatabaseKey { get; set; }

        public string DatabaseName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string EditByUserName { get; set; } = string.Empty;

        public Enum.EnvironmentType EnvironmentType { get; set; } = Enum.EnvironmentType.None;

        public string? PasswordHash { get; set; }

        public string ServerName { get; set; } = string.Empty;

        public string? UserName { get; set; }

    }
}