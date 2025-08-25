namespace barber.Data.Sql.Models
{
    public interface ISqlResult<T> where T : Data.Models.IResponseModel
    {
        System.Collections.Generic.IDictionary<string, object?> ParameterValues { get; }
        System.Collections.Generic.IEnumerable<T> Results { get; }
        int ReturnValue { get; }
        T? SingleResult { get; }
    }
}