namespace barber.CodeGen.Builders
{
    public class StatementTextBuilder : IStatementTextBuilder
    {
        private const string DeleteTemplate = """
DELETE
    FROM {schemaName}.{tableName}
    WHERE {conditionList};
""";

        private const string InsertTemplate = """
INSERT INTO {schemaName}.{tableName} ({columnList})
    SELECT {valueList};
""";

        private const string UpdateTemplate = """
UPDATE {schemaName}.{tableName}
    SET {assignmentList}
    WHERE {conditionList};
""";

        public string? BuildInsert(Models.StatementBuilderOptions options)
        {
            // TODO: Currently very crude.
            var columnList = string.Empty;
            var valueList = string.Empty;
            foreach (var p in options.Parameters)
            {
                columnList += p.Name + ",";
                valueList += "'" + p.Value + "',";
            }
            columnList = columnList.TrimEnd(',');
            valueList = valueList.TrimEnd(',');
            var result = InsertTemplate
                .Replace("{schemaName}", options.SchemaName)
                .Replace("{tableName}", options.TableName)
                .Replace("{columnList}", columnList)
                .Replace("{valueList}", valueList);
            return result;
        }
    }
}