namespace barber.Data.Repositories
{
    public interface IExecuteRepository
    {
        Models.ExecuteResult ExecuteStatement(string statementText, Models.ConnectionOptions options);
        Models.ExecuteResult ValidateStatement(string statementText, Models.ConnectionOptions options);

    }
}