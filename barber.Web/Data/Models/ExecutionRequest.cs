namespace barber.Data.Models
{
    public class ExecutionRequest : IRequestModel
    {
        public ExecutionRequest() { }

        public long DatabaseKey { get; set; } = 0;

        public string ExecuteByUserName { get; set; } = string.Empty;

        public System.DateTime ExecuteDateTime { get; set; } = System.DateTime.MinValue;

        public long ExecuteMs { get; set; } = 0;

        public long RowCount { get; set; } = 0;

        public long StatementKey { get; set; } = 0;
    }
}