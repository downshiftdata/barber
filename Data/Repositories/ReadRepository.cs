namespace barber.Data.Repositories
{
    public class ReadRepository : SqlRepositoryBase, IReadRepository
    {
        public ReadRepository(Models.ISqlContext sqlContext) : base(sqlContext, "barber") { }

        public async System.Threading.Tasks.Task<Models.DatabaseResponse> SelectDatabaseByKey(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("DatabaseKey", key),
            };
            var result = (await base.GetSingle<Models.DatabaseResponse>("Database_SelectByKey", Models.DatabaseResponse.Load, p)).SingleResult;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.DatabaseResponse>> SelectDatabaseHistory(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("DatabaseKey", key),
            };
            var result = (await base.Get<Models.DatabaseResponse>("Database_SelectHistory", Models.DatabaseResponse.Load, p)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.ListResponse>> SelectDatabaseList()
        {
            var result = (await base.Get<Models.ListResponse>("Database_SelectList", Models.ListResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.DatabaseResponse>> SelectDatabases()
        {
            var result = (await base.Get<Models.DatabaseResponse>("Database_Select", Models.DatabaseResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.StatementResponse>> SelectStatementHistory(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", key),
            };
            var result = (await base.Get<Models.StatementResponse>("Statement_SelectHistory", Models.StatementResponse.Load, p)).Results;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<Models.StatementResponse> SelectStatementByKey(long key)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", key),
            };
            var result = (await base.GetSingle<Models.StatementResponse>("Statement_SelectByKey", Models.StatementResponse.Load, p)).SingleResult;
            return result ?? throw new System.InvalidOperationException();
        }

        public async System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.StatementResponse>> SelectStatements()
        {
            var result = (await base.Get<Models.StatementResponse>("Statement_Select", Models.StatementResponse.Load)).Results;
            return result ?? throw new System.InvalidOperationException();
        }
    }
}