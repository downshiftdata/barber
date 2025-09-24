namespace barber.CodeGen.Builders
{
    public interface IStatementBuilder
    {
        Core.Enum.StatementType StatementType { get; }

        string? Build(Models.StatementBuilderOptions options);
    }
}