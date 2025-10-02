namespace barber.CodeGen.Builders
{
    public class InsertStatementBuilder : StatementBuilderBase, IStatementBuilder
    {
        private const string Template = """
INSERT INTO {schemaName}.{tableName} ({columnList})
    SELECT {valueList};
""";

        public Core.Enum.StatementType StatementType => Core.Enum.StatementType.Insert;

        public string? Build(Models.StatementBuilderOptions options)
        {
            var columnList = string.Empty;
            var valueList = string.Empty;
            foreach (var p in options.Parameters)
            {
                columnList += $"{FormatIdentifier(p.Name)},";
                valueList += $"{FormatValue(p.Value, p.DbType)},";
            }
            columnList = columnList.TrimEnd(',');
            valueList = valueList.TrimEnd(',');
            var result = Template
                .Replace("{schemaName}", FormatIdentifier(options.SchemaName))
                .Replace("{tableName}", FormatIdentifier(options.TableName))
                .Replace("{columnList}", columnList)
                .Replace("{valueList}", valueList);
            return result;
        }
    }
}