namespace barber.Data.Extensions
{
    public static class DbCommandExtension
    {
        public static async System.Threading.Tasks.Task ExecuteNonQueryAsync(this System.Data.IDbCommand command)
        {
            if (command == null) throw new System.ArgumentNullException(nameof(command));
            if (command is Microsoft.Data.SqlClient.SqlCommand asCommand)
            {
                _ = await asCommand.ExecuteNonQueryAsync();
            }
            else
            {
                command.ExecuteNonQuery();
            }
        }

        public static async System.Threading.Tasks.Task<System.Data.IDataReader> ExecuteReaderAsync(this System.Data.IDbCommand command)
        {
            if (command == null) throw new System.ArgumentNullException(nameof(command));
            if (command is Microsoft.Data.SqlClient.SqlCommand asCommand)
            {
                return await asCommand.ExecuteReaderAsync();
            }
            else
            {
                return command.ExecuteReader();
            }
        }
    }
}