namespace barber.Data.Models
{
    public class DatabaseRequest : IRequestModel
    {
        public static DatabaseRequest Create(DatabaseResponse response)
        {
            return new DatabaseRequest()
            {
                DatabaseKey = response.DatabaseKey,
                EnvironmentType = response.EnvironmentType,
                ServerName = response.ServerName,
                DatabaseName = response.DatabaseName,
                AuthenticationType = response.AuthenticationType,
                UserName = response.UserName,
                PasswordHash = response.PasswordHash,
                Description = response.Description
            };
        }

        public DatabaseRequest() { }

        public Enum.AuthenticationType AuthenticationType { get; set; } = Enum.AuthenticationType.None;

        public long? DatabaseKey { get; set; }

        public string? DatabaseName { get; set; }

        public string? Description { get; set; }

        public string? EditByUserName { get; set; }

        public Enum.EnvironmentType EnvironmentType { get; set; } = Enum.EnvironmentType.None;

        public string? PasswordHash { get; set; }

        public string? ServerName { get; set; }

        public string? UserName { get; set; }

    }
}