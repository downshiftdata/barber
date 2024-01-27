namespace barber.Data.Models
{
    public class ListResponse : IResponseModel
    {
        static internal ListResponse Load(object[] values)
        {
            return new ListResponse(values);
        }

        public ListResponse(object[] values)
        {
            ItemKey = (long)values[0];
            ItemText = (string)values[1];
        }

        public long ItemKey { get; }

        public string ItemText { get; }
    }
}