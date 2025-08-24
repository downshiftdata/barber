using barber.Data.Extensions;

namespace barber.Data.Models
{
    public class DatabaseResponse : IResponseModel
    {
        static internal DatabaseResponse Load(object[] values)
        {
            return new DatabaseResponse(values);
        }

        public DatabaseResponse(object[] values)
        {
            DatabaseKey = (long?)values[0];
            Revision = (int)values[1];
            EditByUserName = (string)values[2];
            EditDateTime = (System.DateTime)values[3];
            EnvironmentType = (Enum.EnvironmentType)values[4];
            ServerName = (string)values[5];
            DatabaseName = (string)values[6];
            AuthenticationType = (Enum.AuthenticationType)values[7];
            UserName = values[8].DbNullToString();
            PasswordHash = values[9].DbNullToString();
            Description = values[10].DbNullToString();
        }

        public Enum.AuthenticationType AuthenticationType { get; }

        public long? DatabaseKey { get; }

        public string DatabaseName { get; }

        public string? Description { get; }

        public string EditByUserName { get; }

        public System.DateTime EditDateTime { get; }

        public Enum.EnvironmentType EnvironmentType { get; }

        public string? PasswordHash { get; }

        public int Revision { get; }

        public string ServerName { get; }

        public string? UserName { get; }

    }
}