using barber.Data.Extensions;

namespace barber.Data.Models
{
    public class StatementResponse : IResponseModel
    {
        static internal StatementResponse Load(object[] values)
        {
            return new StatementResponse(values);
        }

        public StatementResponse(object[] values)
        {
            StatementKey = (long)values[0];
            Revision = (int)values[1];
            EditByUserName = (string)values[2];
            EditDateTime = (System.DateTime)values[3];
            ValidateByUserName = values[4].DbNullToString();
            ValidateDateTime = values[5].DbNullToDateTime();
            ApproveByUserName = values[6].DbNullToString();
            ApproveDateTime = values[7].DbNullToDateTime();
            Description = (string)values[8];
            StatementType = (Core.Enum.StatementType)values[9];
            SchemaName = values[10].DbNullToString();
            TableName = values[11].DbNullToString();
            StatementText = values[12].DbNullToString();
            StatementDetailJson = values[13].DbNullToString();
            CheckDatabaseKey = (long)values[14];
            CheckDatabaseText = (string?)values[15];
        }

        public string? ApproveByUserName { get; }

        public System.DateTime? ApproveDateTime { get; }

        public long CheckDatabaseKey { get; }

        public string? CheckDatabaseText { get; }

        public string Description { get; }

        public string EditByUserName { get; }

        public System.DateTime EditDateTime { get; }

        public int Revision { get; }

        public string? SchemaName { get; }

        public string? StatementDetailJson { get; }

        public long StatementKey { get; }

        public string? StatementText { get; }

        public Core.Enum.StatementType StatementType { get; }

        public string? TableName { get; }

        public string? ValidateByUserName { get; }

        public System.DateTime? ValidateDateTime { get; }
    }
}