namespace barber.CodeGen.Builders
{
    public class UpdateStatementBuilder : IStatementBuilder
    {
        private const string Template = """
UPDATE {schemaName}.{tableName}
    SET {setList}
    WHERE {whereList};
""";

        public Core.Enum.StatementType StatementType => Core.Enum.StatementType.Update;

        public string? Build(Models.StatementBuilderOptions options)
        {
            // TODO: Currently very crude.
            var setList = string.Empty;
            var whereList = string.Empty;
            foreach (var p in options.Parameters)
            {
                if (p.IsFilter)
                {
                    whereList += $" AND {p.Name} = '{p.Value}'";
                }
                else
                {
                    setList += $"{p.Name} = '{p.Value}',";
                }
            }
            setList = setList.TrimEnd(',');
            whereList = whereList.Remove(0, 5);
            var result = Template
                .Replace("{schemaName}", options.SchemaName)
                .Replace("{tableName}", options.TableName)
                .Replace("{setList}", setList)
                .Replace("{whereList}", whereList);
            return result;
        }
    }
}