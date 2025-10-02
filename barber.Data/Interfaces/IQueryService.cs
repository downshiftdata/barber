namespace barber.Data.Interfaces
{
    public interface IQueryService
    {
        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.ListResponse>> SelectApprovedStatementList();

        System.Threading.Tasks.Task<Models.DatabaseResponse> SelectDatabaseByKey(long key);

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.DatabaseResponse>> SelectDatabaseHistory(long key);

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.ListResponse>> SelectDatabaseList();

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.DatabaseResponse>> SelectDatabases();

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.StatementResponse>> SelectStatementHistory(long key);

        System.Threading.Tasks.Task<Models.StatementResponse> SelectStatementByKey(long key);

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.StatementResponse>> SelectStatements();

        System.Threading.Tasks.Task<Models.UserResponse?> SelectUserByCredentials(string userName, string passwordHash);

        System.Threading.Tasks.Task<Models.UserResponse> SelectUserByName(string userName);

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.UserResponse>> SelectUserHistory(string userName);

        System.Threading.Tasks.Task<System.Collections.Generic.IEnumerable<Models.UserResponse>> SelectUsers();

    }
}