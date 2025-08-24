namespace barber.Data.Models
{
    public interface ISqlResult<T> where T : IResponseModel
    {
        System.Collections.Generic.IDictionary<string, object?> ParameterValues { get; }
        System.Collections.Generic.IEnumerable<T> Results { get; }
        int ReturnValue { get; }
        T? SingleResult { get; }
    }
}