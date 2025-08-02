namespace barber.Statements.Builders
{
    public interface IStatementTextBuilder
    {
        string? Build(Data.Models.StatementResponse statement);
    }
}