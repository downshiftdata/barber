namespace barber.Data.Repositories
{
    public class ExecuteRepository : IExecuteRepository
    {
        private const string AdHocTemplate = "/* barber */\r\n{parseOnly}{statement}\r\nSELECT @@ROWCOUNT;";

        private const string AuthXIntegrated = "Integrated Security=SSPI";

        private const string AuthXUserNameAndPassword = "User Name={0};Password={1}";

        private const string ConnectionStringTemplate = "Data Source={0};Initial Catalog={1};{2};Application Name=barber;TrustServerCertificate=true";

        private const string ParseOnlyOn = "SET PARSEONLY ON;\r\n";

        public ExecuteRepository() { }

        public Models.ExecuteResult ExecuteStatement(string statementText, Models.ConnectionOptions options)
        {
            try
            {
                var result = ExecuteAdHoc(statementText, false, options);
                return new Models.ExecuteResult(true, result.ReturnValue, null);
            }
            catch (System.Exception ex)
            {
                return new Models.ExecuteResult(false, 0, ex);
            }
        }

        public Models.ExecuteResult ValidateStatement(string statementText, Models.ConnectionOptions options)
        {
            try
            {
                var result = ExecuteAdHoc(statementText, true, options);
                return new Models.ExecuteResult(true, result.ReturnValue, null);
            }
            catch (System.Exception ex)
            {
                return new Models.ExecuteResult(false, 0, ex);
            }
        }

        private static Models.SqlResult<Models.NoResponseModel> ExecuteAdHoc(string statement, bool parseOnly, Models.ConnectionOptions options)
        {
            var rowCount = 0;
            using (var connection = new Microsoft.Data.SqlClient.SqlConnection(GetConnectionString(options)))
            {
                using (var command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = AdHocTemplate
                        .Replace("{parseOnly}", parseOnly ? ParseOnlyOn : string.Empty)
                        .Replace("{statement}", statement);
                    command.CommandType = System.Data.CommandType.Text;
                    rowCount = (int?)command.ExecuteScalar() ?? 0;
                }
            }
            return new Models.SqlResult<Models.NoResponseModel>(rowCount, null, null, null);
        }

        private static string GetConnectionString(Models.ConnectionOptions options)
        {
            var authX = (options.UserName is null || options.Password is null)
                ? AuthXIntegrated
                : string.Format(AuthXUserNameAndPassword, options.UserName, options.Password);
            var result = string.Format(ConnectionStringTemplate, options.ServerName, options.DatabaseName, authX);
            return result;
        }
    }
}