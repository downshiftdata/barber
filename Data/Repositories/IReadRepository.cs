namespace barber.Data.Repositories
{
    public interface IReadRepository
    {
        System.Threading.Tasks.Task<Models.DatabaseResponse> SelectDatabaseByKey(long key);

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.ListResponse>> SelectDatabaseList();

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.DatabaseResponse>> SelectDatabases();

        System.Threading.Tasks.Task<Models.StatementResponse> SelectStatementByKey(long key);

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.StatementResponse>> SelectStatements();

    }
}