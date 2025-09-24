namespace barber.CodeGen.Services
{
    public interface IStatementService
    {
        string? Build(Data.Models.StatementRequest request);
    }
}