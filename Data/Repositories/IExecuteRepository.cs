namespace barber.Data.Repositories
{
    public interface IExecuteRepository
    {
        Models.ExecuteResult ValidateStatement(string statementText, Models.ConnectionOptions options);

    }
}