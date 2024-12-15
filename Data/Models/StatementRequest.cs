namespace barber.Data.Models
{
    public class StatementRequest : IRequestModel
    {
        public static StatementRequest Create(StatementResponse response)
        {
            return new StatementRequest()
            {
                StatementKey = response.StatementKey,
                StatementType = response.StatementType,
                StatementText = response.StatementText,
                StatementJson = response.StatementJson,
                CheckDatabaseKey = response.CheckDatabaseKey
            };
        }

        public StatementRequest() { }

        public string ApproveByUserName { get; set; } = string.Empty;

        public long CheckDatabaseKey { get; set; } = 0;

        public string EditByUserName { get; set; } = string.Empty;

        public string? StatementJson { get; set; }

        public long? StatementKey { get; set; }

        public string? StatementText { get; set; }

        public Enum.StatementType StatementType { get; set; } = Enum.StatementType.None;

    }
}