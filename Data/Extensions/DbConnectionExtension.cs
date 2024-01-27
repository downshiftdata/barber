namespace barber.Data.Extensions
{
    public static class DbConnectionExtension
    {
        public static async System.Threading.Tasks.Task OpenAsync(this System.Data.IDbConnection connection)
        {
            if (connection == null) throw new System.ArgumentNullException(nameof(connection));
            if (connection is Microsoft.Data.SqlClient.SqlConnection asConnection)
            {
                await asConnection.OpenAsync();
            }
            else
            {
                connection.Open();
            }
        }
    }
}