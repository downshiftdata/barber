namespace barber.Data.Models
{
    public class WriteResult
    {
        public WriteResult(bool isSuccessful, long? key)
        {
            IsSuccessful = isSuccessful;
            Key = key;
        }

        public bool IsSuccessful { get; }

        public long? Key { get; }
    }
}