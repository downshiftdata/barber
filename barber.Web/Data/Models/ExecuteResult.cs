namespace barber.Data.Models
{
    public class ExecuteResult
    {
        public ExecuteResult(bool isSuccessful, long rowCount, System.Exception? exception)
        {
            IsSuccessful = isSuccessful;
            RowCount = rowCount;
            Exception = exception;
        }

        public System.Exception? Exception { get; }

        public bool IsSuccessful { get; }

        public long RowCount { get; }
    }
}