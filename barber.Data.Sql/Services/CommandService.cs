namespace barber.Data.Sql.Services
{
    public class CommandService : SqlServiceBase, Data.Interfaces.ICommandService
    {
        public CommandService(Models.ISqlContext sqlContext) : base(sqlContext, "barber") { }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> ApproveStatement(Data.Models.StatementRequest request)
        {
            if (request.StatementKey is null) throw new System.ArgumentNullException("StatementKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", request.StatementKey),
                base.CreateStringParameter("ApproveByUserName", request.ApproveByUserName)
            };
            var result = await base.Execute("Statement_Approve", p);
            return new Data.Models.WriteResult(result.ReturnValue == 1, request.StatementKey);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> InsertExecution(Data.Models.ExecutionRequest request)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameterWithOutput("ExecutionKey", System.DBNull.Value),
                base.CreateKeyParameter("DatabaseKey", request.DatabaseKey),
                base.CreateKeyParameter("StatementKey", request.StatementKey),
                base.CreateStringParameter("ExecuteByUserName", request.ExecuteByUserName),
                base.CreateDateTimeParameter("ExecuteDateTime", request.ExecuteDateTime),
                base.CreateLongParameter("ExecuteMs", request.ExecuteMs),
                base.CreateLongParameter("RowCount", request.RowCount)
            };
            var result = await base.Execute("Execution_Insert", p);
            var key = (long?)result.ParameterValues["ExecutionKey"];
            return new Data.Models.WriteResult(result.ReturnValue == 1, key);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> InsertDatabase(Data.Models.DatabaseRequest request)
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
                base.CreateStringParameter("Description", request.Description)
            };
            var result = await base.Execute("Database_Insert", p);
            var key = (long?)result.ParameterValues["DatabaseKey"];
            return new Data.Models.WriteResult(result.ReturnValue == 1, key);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> InsertStatement(Data.Models.StatementRequest request)
        {
            if (request.StatementKey is not null) throw new System.ArgumentNullException("StatementKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameterWithOutput("StatementKey", System.DBNull.Value),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateStringParameter("Description", request.Description),
                base.CreateEnumParameter("StatementType", request.StatementType),
                base.CreateStringParameter("SchemaName", request.SchemaName),
                base.CreateStringParameter("TableName", request.TableName),
                base.CreateStringParameter("StatementText", request.StatementText, SqlServiceBase.MaxStringLength),
                base.CreateJsonParameter("StatementDetailJson", request.StatementDetailJson),
                base.CreateKeyParameter("CheckDatabaseKey", request.CheckDatabaseKey)
            };
            var result = await base.Execute("Statement_Insert", p);
            var key = (long?)result.ParameterValues["StatementKey"];
            return new Data.Models.WriteResult(result.ReturnValue == 1, key);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> InsertUser(Data.Models.UserRequest request)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateStringParameter("UserName", request.UserName),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateStringParameter("PasswordHash", request.PasswordHash),
                base.CreateBoolParameter("IsAdmin", request.IsAdmin),
                base.CreateBoolParameter("IsEditor", request.IsEditor),
                base.CreateBoolParameter("IsApprover", request.IsApprover),
                base.CreateBoolParameter("IsExecutor", request.IsExecutor),
                base.CreateBoolParameter("AllowCustom", request.AllowCustom)
            };
            var result = await base.Execute("User_Insert", p);
            return new Data.Models.WriteResult(result.ReturnValue == 1, null);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> UpdateDatabase(Data.Models.DatabaseRequest request)
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
                base.CreateStringParameter("Description", request.Description)
            };
            var result = await base.Execute("Database_Update", p);
            return new Data.Models.WriteResult(result.ReturnValue == 1, request.DatabaseKey);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> UpdateStatement(Data.Models.StatementRequest request)
        {
            if (request.StatementKey is null) throw new System.ArgumentNullException("StatementKey");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", request.StatementKey),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateStringParameter("Description", request.Description),
                base.CreateEnumParameter("StatementType", request.StatementType),
                base.CreateStringParameter("SchemaName", request.SchemaName),
                base.CreateStringParameter("TableName", request.TableName),
                base.CreateStringParameter("StatementText", request.StatementText, SqlServiceBase.MaxStringLength),
                base.CreateJsonParameter("StatementDetailJson", request.StatementDetailJson),
                base.CreateKeyParameter("CheckDatabaseKey", request.CheckDatabaseKey)
            };
            var result = await base.Execute("Statement_Update", p);
            return new Data.Models.WriteResult(result.ReturnValue == 1, request.StatementKey);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> UpdateUser(Data.Models.UserRequest request)
        {
            var p = new System.Data.IDataParameter[]
            {
                base.CreateStringParameter("UserName", request.UserName),
                base.CreateStringParameter("EditByUserName", request.EditByUserName),
                base.CreateStringParameter("PasswordHash", request.PasswordHash),
                base.CreateBoolParameter("IsAdmin", request.IsAdmin),
                base.CreateBoolParameter("IsEditor", request.IsEditor),
                base.CreateBoolParameter("IsApprover", request.IsApprover),
                base.CreateBoolParameter("IsExecutor", request.IsExecutor),
                base.CreateBoolParameter("AllowCustom", request.AllowCustom)
            };
            var result = await base.Execute("User_Update", p);
            return new Data.Models.WriteResult(result.ReturnValue == 1, null);
        }

        public async System.Threading.Tasks.Task<Data.Models.WriteResult> ValidateStatement(Data.Models.StatementRequest request)
        {
            if (request.StatementKey is null) throw new System.ArgumentNullException("StatementKey");
            if (request.StatementText is null) throw new System.ArgumentNullException("StatementText");
            var p = new System.Data.IDataParameter[]
            {
                base.CreateKeyParameter("StatementKey", request.StatementKey),
                base.CreateStringParameter("ValidateByUserName", request.ValidateByUserName)
            };
            var result = await base.Execute("Statement_Validate", p);
            return new Data.Models.WriteResult(result.ReturnValue == 1, request.StatementKey);
        }
    }
}