namespace barber.Statements.Builders
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

        public string? Build(Data.Models.StatementResponse statement)
        {
            switch (statement.StatementType)
            {
                case Enum.StatementType.None:
                    return null;
                case Enum.StatementType.Custom:
                    return statement.StatementText;
                case Enum.StatementType.Insert:
                    return BuildInsert(statement);
                default:
                    throw new System.NotImplementedException();
            }
        }

        private static string? BuildInsert(Data.Models.StatementResponse statement)
        {
            // TODO: Currently very crude.
            if (statement.StatementDetailJson is null) return null;
            var parameters = System.Text.Json.JsonSerializer.Deserialize<Models.StatementDetail>(statement.StatementDetailJson)!.Parameters;
            var columnList = string.Empty;
            var valueList = string.Empty;
            foreach (var p in parameters)
            {
                columnList += p.Name + ",";
                valueList += "'" + p.Value + "',";
            }
            columnList = columnList.TrimEnd(',');
            valueList = valueList.TrimEnd(',');
            var result = InsertTemplate
                .Replace("{schemaName}", statement.SchemaName)
                .Replace("{tableName}", statement.TableName)
                .Replace("{columnList}", columnList)
                .Replace("{valueList}", valueList);
            return result;
        }
    }
}