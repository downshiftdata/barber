namespace barber.Data.Sql.Services
{
    public class QueryService : SqlServiceBase, Data.Interfaces.IQueryService
    {
        public QueryService(Models.ISqlContext sqlContext) : base(sqlContext, "barber") { }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.ListResponse>> SelectApprovedStatementList()
        {
            var result = (await base.Get<Data.Models.ListResponse>("Statement_SelectApprovedList", Data.Models.ListResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<Data.Models.DatabaseResponse> SelectDatabaseByKey(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("DatabaseKey", key),
            };
            var result = (await base.GetSingle<Data.Models.DatabaseResponse>("Database_SelectByKey", Data.Models.DatabaseResponse.Load, p)).SingleResult;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.DatabaseResponse>> SelectDatabaseHistory(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("DatabaseKey", key),
            };
            var result = (await base.Get<Data.Models.DatabaseResponse>("Database_SelectHistory", Data.Models.DatabaseResponse.Load, p)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.ListResponse>> SelectDatabaseList()
        {
            var result = (await base.Get<Data.Models.ListResponse>("Database_SelectList", Data.Models.ListResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.DatabaseResponse>> SelectDatabases()
        {
            var result = (await base.Get<Data.Models.DatabaseResponse>("Database_Select", Data.Models.DatabaseResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.StatementResponse>> SelectStatementHistory(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", key),
            };
            var result = (await base.Get<Data.Models.StatementResponse>("Statement_SelectHistory", Data.Models.StatementResponse.Load, p)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<Data.Models.StatementResponse> SelectStatementByKey(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", key),
            };
            var result = (await base.GetSingle<Data.Models.StatementResponse>("Statement_SelectByKey", Data.Models.StatementResponse.Load, p)).SingleResult;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.StatementResponse>> SelectStatements()
        {
            var result = (await base.Get<Data.Models.StatementResponse>("Statement_Select", Data.Models.StatementResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<Data.Models.UserResponse?> SelectUserByCredentials(string userName, string passwordHash)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateStringParameter("UserName", userName),
                base.CreateStringParameter("PasswordHash", passwordHash)
            };
            var result = (await base.GetSingle<Data.Models.UserResponse>("User_SelectByCredentials", Data.Models.UserResponse.Load, p)).SingleResult;
            return result;
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.UserResponse>> SelectUserHistory(string userName)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateStringParameter("UserName", userName),
            };
            var result = (await base.Get<Data.Models.UserResponse>("User_SelectHistory", Data.Models.UserResponse.Load, p)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<Data.Models.UserResponse> SelectUserByName(string userName)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateStringParameter("UserName", userName)
            };
            var result = (await base.GetSingle<Data.Models.UserResponse>("User_SelectByName", Data.Models.UserResponse.Load, p)).SingleResult;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Data.Models.UserResponse>> SelectUsers()
        {
            var result = (await base.Get<Data.Models.UserResponse>("User_Select", Data.Models.UserResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }
    }
}