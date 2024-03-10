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
            StatementType = (Enum.StatementType)values[6];
            StatementText = values[7].DbNullToString();
            StatementJson = values[8].DbNullToString();
            CheckDatabaseKey = (long)values[9];
            CheckDatabaseText = (string?)values[10];
        }

        public string? ApproveByUserName { get; }

        public System.DateTime? ApproveDateTime { get; }

        public long CheckDatabaseKey { get; }

        public string? CheckDatabaseText { get; }

        public string EditByUserName { get; }

        public System.DateTime EditDateTime { get; }

        public int Revision { get; }

        public string? StatementJson { get; }

        public long StatementKey { get; }

        public string? StatementText { get; }

        public Enum.StatementType StatementType { get; }

    }
}