namespace barber.Statements.Models
{
    public class Parameter
    {
        public string Name { get; set; } = string.Empty;
        public System.Data.DbType DbType { get; set; } = System.Data.DbType.String;
        public string Value { get; set; } = string.Empty;
    }
}