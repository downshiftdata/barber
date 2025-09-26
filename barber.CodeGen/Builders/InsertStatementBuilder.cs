namespace barber.CodeGen.Builders
{
    public class InsertStatementBuilder : IStatementBuilder
    {
        private const string Template = """
INSERT INTO {schemaName}.{tableName} ({columnList})
    SELECT {valueList};
""";

        public Core.Enum.StatementType StatementType => Core.Enum.StatementType.Insert;

        public string? Build(Models.StatementBuilderOptions options)
        {
            // TODO: Currently very crude.
            var columnList = string.Empty;
            var valueList = string.Empty;
            foreach (var p in options.Parameters)
            {
                columnList += $"{p.Name},";
                valueList += $"'{p.Value}',";
            }
            columnList = columnList.TrimEnd(',');
            valueList = valueList.TrimEnd(',');
            var result = Template
                .Replace("{schemaName}", options.SchemaName)
                .Replace("{tableName}", options.TableName)
                .Replace("{columnList}", columnList)
                .Replace("{valueList}", valueList);
            return result;
        }
    }
}