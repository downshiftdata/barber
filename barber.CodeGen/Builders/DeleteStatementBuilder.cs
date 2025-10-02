namespace barber.CodeGen.Builders
{
    public class DeleteStatementBuilder : StatementBuilderBase, IStatementBuilder
    {
        private const string Template = """
DELETE
    FROM {schemaName}.{tableName}
    WHERE {whereList};
""";

        public Core.Enum.StatementType StatementType => Core.Enum.StatementType.Delete;

        public string? Build(Models.StatementBuilderOptions options)
        {
            var whereList = string.Empty;
            foreach (var p in options.Parameters)
            {
                if (p.IsFilter)
                {
                    whereList += $" AND {FormatIdentifier(p.Name)} = {FormatValue(p.Value, p.DbType)}";
                }
            }
            whereList = whereList.Remove(0, 5);
            var result = Template
                .Replace("{schemaName}", FormatIdentifier(options.SchemaName))
                .Replace("{tableName}", FormatIdentifier(options.TableName))
                .Replace("{whereList}", whereList);
            return result;
        }
    }
}