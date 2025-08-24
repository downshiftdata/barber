namespace barber.Data.Models
{
    public class StatementRequest : IRequestModel
    {
        public static StatementRequest Create(StatementResponse response)
        {
            return new StatementRequest()
            {
                StatementKey = response.StatementKey,
                Description = response.Description,
                StatementType = response.StatementType,
                SchemaName = response.SchemaName,
                TableName = response.TableName,
                StatementText = response.StatementText,
                StatementDetailJson = response.StatementDetailJson,
                CheckDatabaseKey = response.CheckDatabaseKey
            };
        }

        public StatementRequest() { }

        public string ApproveByUserName { get; set; } = string.Empty;

        public long CheckDatabaseKey { get; set; } = 0;

        public string Description { get; set; } = string.Empty;

        public string EditByUserName { get; set; } = string.Empty;

        public string? SchemaName { get; set; }

        public string? StatementDetailJson { get; set; }

        public long? StatementKey { get; set; }

        public string? StatementText { get; set; }

        public Core.Enum.StatementType StatementType { get; set; } = Core.Enum.StatementType.None;

        public string? TableName { get; set; }

        public string ValidateByUserName { get; set; } = string.Empty;
    }
}