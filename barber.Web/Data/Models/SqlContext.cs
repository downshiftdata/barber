using Microsoft.Extensions.Configuration;

namespace barber.Data.Models
{
    public class SqlContext : ISqlContext
    {
        private readonly IConfiguration _Configuration;

        public SqlContext(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public System.Data.IDbConnection GetConnection()
        {
            return new Microsoft.Data.SqlClient.SqlConnection(_Configuration.GetConnectionString("barber-main"));
        }
    }
}