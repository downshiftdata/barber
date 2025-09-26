namespace barber.CodeGen.Builders
{
    public class DeleteStatementBuilder : IStatementBuilder
    {
        private const string Template = """
DELETE
    FROM {schemaName}.{tableName}
    WHERE {whereList};
""";

        public Core.Enum.StatementType StatementType => Core.Enum.StatementType.Delete;

        public string? Build(Models.StatementBuilderOptions options)
        {
            // TODO: Currently very crude.
            var whereList = string.Empty;
            foreach (var p in options.Parameters)
            {
                if (p.IsFilter)
                {
                    whereList += $" AND {p.Name} = '{p.Value}'";
                }
            }
            whereList = whereList.Remove(0, 5);
            var result = Template
                .Replace("{schemaName}", options.SchemaName)
                .Replace("{tableName}", options.TableName)
                .Replace("{whereList}", whereList);
            return result;
        }
    }
}