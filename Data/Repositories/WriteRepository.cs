namespace barber.Data.Repositories
{
    public class WriteRepository : SqlRepositoryBase, IWriteRepository
    {
        public WriteRepository(Models.ISqlContext sqlContext) : base(sqlContext, "barber") { }

        public async System.Threading.Tasks.Task<Models.WriteResult> ApproveStatement(Models.StatementRequest request)
        {
            if (request.StatementKey is null) throw new System.ArgumentNullException("StatementKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", request.StatementKey),
                base.CreateStringParameter("ApproveByUserName", request.ApproveByUserName),
            };
            var result = await base.Execute("Statement_Approve", p);
            return new Models.WriteResult(result.ReturnValue == 1, request.StatementKey);
        }

        public async System.Threading.Tasks.Task<Models.WriteResult> InsertDatabase(Models.DatabaseRequest request)
        {
            if (request.DatabaseKey is not null) throw new System.ArgumentNullException("DatabaseKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameterWithOutput("DatabaseKey", System.DBNull.Value),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateEnumParameter("EnvironmentType", request.EnvironmentType),
                base.CreateStringParameter("ServerName", request.ServerName),
                base.CreateStringParameter("DatabaseName", request.DatabaseName),
                base.CreateEnumParameter("AuthenticationType", request.AuthenticationType),
                base.CreateStringParameter("UserName", request.UserName),
                base.CreateStringParameter("PasswordHash", request.PasswordHash),
            };
            var result = await base.Execute("Database_Insert", p);
            var key = (long?)result.ParameterValues["DatabaseKey"];
            return new Models.WriteResult(result.ReturnValue == 1, key);
        }

        public async System.Threading.Tasks.Task<Models.WriteResult> InsertStatement(Models.StatementRequest request)
        {
            if (request.StatementKey is not null) throw new System.ArgumentNullException("StatementKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameterWithOutput("StatementKey", System.DBNull.Value),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateEnumParameter("StatementType", request.StatementType),
                base.CreateStringParameter("StatementText", request.StatementText, SqlRepositoryBase.MaxStringLength),
                base.CreateJsonParameter("StatementJson", request.StatementJson),
                base.CreateKeyParameter("CheckDatabaseKey", request.CheckDatabaseKey)
            };
            var result = await base.Execute("Statement_Insert", p);
            var key = (long?)result.ParameterValues["StatementKey"];
            return new Models.WriteResult(result.ReturnValue == 1, key);
        }

        public async System.Threading.Tasks.Task<Models.WriteResult> UpdateDatabase(Models.DatabaseRequest request)
        {
            if (request.DatabaseKey is null) throw new System.ArgumentNullException("DatabaseKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("DatabaseKey", request.DatabaseKey),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateEnumParameter("EnvironmentType", request.EnvironmentType),
                base.CreateStringParameter("ServerName", request.ServerName),
                base.CreateStringParameter("DatabaseName", request.DatabaseName),
                base.CreateEnumParameter("AuthenticationType", request.AuthenticationType),
                base.CreateStringParameter("UserName", request.UserName),
                base.CreateStringParameter("PasswordHash", request.PasswordHash),
            };
            var result = await base.Execute("Database_Update", p);
            return new Models.WriteResult(result.ReturnValue == 1, request.DatabaseKey);
        }

        public async System.Threading.Tasks.Task<Models.WriteResult> UpdateStatement(Models.StatementRequest request)
        {
            if (request.StatementKey is null) throw new System.ArgumentNullException("StatementKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", request.StatementKey),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateEnumParameter("StatementType", request.StatementType),
                base.CreateStringParameter("StatementText", request.StatementText, SqlRepositoryBase.MaxStringLength),
                base.CreateJsonParameter("StatementJson", request.StatementJson),
                base.CreateKeyParameter("CheckDatabaseKey", request.CheckDatabaseKey)
            };
            var result = await base.Execute("Statement_Update", p);
            return new Models.WriteResult(result.ReturnValue == 1, request.StatementKey);
        }
    }
}