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
            ApproveByUserName = values[4].DbNullToString();
            ApproveDateTime = values[5].DbNullToDateTime();
            Description = (string)values[6];
            StatementType = (Enum.StatementType)values[7];
            StatementText = values[8].DbNullToString();
            StatementJson = values[9].DbNullToString();
            CheckDatabaseKey = (long)values[10];
            CheckDatabaseText = (string?)values[11];
        }

        public string? ApproveByUserName { get; }

        public System.DateTime? ApproveDateTime { get; }

        public long CheckDatabaseKey { get; }

        public string? CheckDatabaseText { get; }

        public string Description { get; }

        public string EditByUserName { get; }

        public System.DateTime EditDateTime { get; }

        public int Revision { get; }

        public string? StatementJson { get; }

        public long StatementKey { get; }

        public string? StatementText { get; }

        public Enum.StatementType StatementType { get; }

    }
}