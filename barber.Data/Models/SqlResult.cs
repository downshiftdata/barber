namespace barber.Data.Models
{
    public class SqlResult<T> : ISqlResult<T> where T : IResponseModel
    {
        private System.Collections.Generic.IDictionary<string, object?>? _ParameterValues;
        private System.Collections.Generic.IEnumerable<T>? _Results;

        internal SqlResult(
            int returnValue,
            System.Collections.Generic.IDictionary<string, object?>? parameterValues,
            System.Collections.Generic.IEnumerable<T>? results,
            T? singleResult)
        {
            _ParameterValues = parameterValues;
            _Results = results;
            ReturnValue = returnValue;
            SingleResult = singleResult;
        }

        public System.Collections.Generic.IDictionary<string, object?> ParameterValues
        {
            get
            {
                return _ParameterValues ?? new System.Collections.Generic.Dictionary<string, object?>();
            }
        }

        public System.Collections.Generic.IEnumerable<T> Results
        {
            get
            {
                return _Results ?? new System.Collections.Generic.List<T>();
            }
        }

        public int ReturnValue { get; }

        public T? SingleResult { get; }
    }
}