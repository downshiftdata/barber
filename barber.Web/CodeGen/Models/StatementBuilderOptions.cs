namespace barber.CodeGen.Models
{
    public class StatementBuilderOptions
    {

        public required string SchemaName { get; set; }

        public required System.Collections.Generic.IEnumerable<StatementParameter> Parameters { get; set; }

        public Core.Enum.StatementType StatementType { get; set; } = Core.Enum.StatementType.None;

        public required string TableName { get; set; }
    }
}