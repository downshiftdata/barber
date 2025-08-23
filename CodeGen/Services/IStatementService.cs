namespace barber.CodeGen.Services
{
    public interface IStatementService
    {
        string? GetStatementText(Data.Models.StatementRequest request);
    }
}