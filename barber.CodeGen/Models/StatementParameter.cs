namespace barber.CodeGen.Models
{
    public class StatementParameter
    {
        public System.Data.DbType DbType { get; set; } = System.Data.DbType.String;
        public bool IsFilter { get; set; } = false;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}