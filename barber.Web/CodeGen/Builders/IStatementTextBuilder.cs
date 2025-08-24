namespace barber.CodeGen.Builders
{
    public interface IStatementTextBuilder
    {
        string? BuildInsert(Models.StatementBuilderOptions options);
    }
}