using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using barber.Data.Extensions;

namespace barber.Data.Repositories
{
    public abstract class SqlRepositoryBase
    {
        public const int DefaultPrecision = 18;

        public const int DefaultScale = 6;

        public const int DefaultStringLength = 128;

        public const int MaxStringLength = -1;

        private readonly Models.ISqlContext _Context;

        private readonly string _SchemaName;

        protected SqlRepositoryBase(Models.ISqlContext context, string schemaName)
        {
            _Context = context;
            _SchemaName = schemaName;
        }

        protected System.Data.IDataParameter CreateBoolParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.Bit, 0, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateDateTimeParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.DateTime, 0, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateDecimalParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.Decimal, 0, DefaultPrecision, DefaultScale, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateEnumParameter(string name, object value)
            => CreateParameter(name, (int)value, System.Data.SqlDbType.Int, 0, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateGuidParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.UniqueIdentifier, 0, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateIntParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.Int, 0, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateJsonParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.NVarChar, MaxStringLength, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateKeyParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.BigInt, 0, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateKeyParameterWithOutput(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.BigInt, 0, 0, 0, System.Data.ParameterDirection.InputOutput);

        protected System.Data.IDataParameter CreateStringParameter(string name, object? value)
            => CreateParameter(name, value, System.Data.SqlDbType.NVarChar, DefaultStringLength, 0, 0, System.Data.ParameterDirection.Input);

        protected System.Data.IDataParameter CreateStringParameter(string name, object? value, int length)
            => CreateParameter(name, value, System.Data.SqlDbType.NVarChar, length, 0, 0, System.Data.ParameterDirection.Input);

        private System.Data.IDataParameter CreateParameter(
            string name,
            object? value,
            System.Data.SqlDbType type,
            int size,
            byte precision,
            byte scale,
            System.Data.ParameterDirection direction)
        {
            var p = new SqlParameter(string.Format("@{0}", name), type)
            {
                Direction = direction,
                Value = value == null ? System.DBNull.Value : value
            };
            if (size != 0) p.Size = size;
            if (precision != 0) p.Precision = precision;
            if (scale != 0) p.Scale = scale;
            return p;
        }

        public async System.Threading.Tasks.Task<Models.ISqlResult<Models.NoResponseModel>> Execute(string procedureName)
            => await Execute(procedureName, null);

        public async System.Threading.Tasks.Task<Models.ISqlResult<Models.NoResponseModel>> Execute(string procedureName, System.Data.IDataParameter[]? parameters)
        {
            (int returnValue, IDictionary<string, object?>? values) v = (0, null);
            using (var connection = _Context.GetConnection())
            {
                using (var command = GetCommand(connection, procedureName))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    v = GetValues(command.Parameters);
                }
            }
            return new Models.SqlResult<Models.NoResponseModel>(v.returnValue, v.values, null, null);
        }

        public async System.Threading.Tasks.Task<Models.ISqlResult<T>> Get<T>(
            string procedureName,
            System.Func<object[], T> loader)
            where T : Models.IResponseModel
            => await Get<T>(procedureName, loader, null);

        public async System.Threading.Tasks.Task<Models.ISqlResult<T>> Get<T>(
            string procedureName,
            System.Func<object[], T> loader,
            System.Data.IDataParameter[]? parameters)
            where T : Models.IResponseModel
        {
            (int returnValue, IDictionary<string, object?>? values) v = (0, null);
            var values = new List<T>();
            using (var connection = _Context.GetConnection())
            {
                using (var command = GetCommand(connection, procedureName))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var row = new object[reader.FieldCount];
                            reader.GetValues(row);
                            values.Add(loader(row));
                        }
                    }
                    v = GetValues(command.Parameters);
                }
            }
            return new Models.SqlResult<T>(v.returnValue, v.values, values, default(T));
        }

        private System.Data.IDbCommand GetCommand(System.Data.IDbConnection connection, string procedureName)
        {
            var command = connection.CreateCommand();
            command.CommandText = string.Format("[{0}].[{1}]", _SchemaName, procedureName);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@RETURN_VALUE", System.Data.SqlDbType.Int)
            {
                Direction = System.Data.ParameterDirection.ReturnValue
            });
            return command;
        }

        public async System.Threading.Tasks.Task<Models.ISqlResult<T>> GetSingle<T>(
            string procedureName,
            System.Func<object[], T> loader)
            where T : Models.IResponseModel
            => await GetSingle<T>(procedureName, loader, null);

        public async System.Threading.Tasks.Task<Models.ISqlResult<T>> GetSingle<T>(
            string procedureName,
            System.Func<object[], T> loader,
            System.Data.IDataParameter[]? parameters)
            where T : Models.IResponseModel
        {
            (int returnValue, IDictionary<string, object?>? values) v = (0, null);
            T? singleValue = default;
            using (var connection = _Context.GetConnection())
            {
                using (var command = GetCommand(connection, procedureName))
                {
                    if (parameters != null) command.Parameters.AddRange(parameters);
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            var row = new object[reader.FieldCount];
                            reader.GetValues(row);
                            singleValue = loader(row);
                        }
                    }
                    v = GetValues(command.Parameters);
                }
            }
            return new Models.SqlResult<T>(v.returnValue, v.values, null, singleValue);
        }

        private (int returnValue, IDictionary<string, object?>? values) GetValues(System.Data.IDataParameterCollection parameters)
        {
            var returnValue = 0;
            var values = new Dictionary<string, object?>();
            foreach (System.Data.IDataParameter p in parameters)
            {
                switch (p.Direction)
                {
                    case System.Data.ParameterDirection.ReturnValue:
                        returnValue = (int)(p.Value ?? 0);
                        break;
                    case System.Data.ParameterDirection.InputOutput:
                    case System.Data.ParameterDirection.Output:
                        values.Add(p.ParameterName.Trim('@'), p.Value);
                        break;
                    default:
                        break;
                }
            }
            if (values.Count == 0) values = null;
            return (returnValue, values);
        }
    }
}