namespace barber.CodeGen.Builders
{
    public class UpdateStatementBuilder : StatementBuilderBase, IStatementBuilder
    {
        private const string Template = """
UPDATE {schemaName}.{tableName}
    SET {setList}
    WHERE {whereList};
""";

        public Core.Enum.StatementType StatementType => Core.Enum.StatementType.Update;

        public string? Build(Models.StatementBuilderOptions options)
        {
            var setList = string.Empty;
            var whereList = string.Empty;
            foreach (var p in options.Parameters)
            {
                if (p.IsFilter)
                {
                    whereList += $" AND {FormatIdentifier(p.Name)} = {FormatValue(p.Value, p.DbType)}";
                }
                else
                {
                    setList += $"{FormatIdentifier(p.Name)} = {FormatValue(p.Value, p.DbType)},";
                }
            }
            setList = setList.TrimEnd(',');
            if (whereList.Length > 5) whereList = whereList.Remove(0, 5); /* " AND " */
            var result = Template
                .Replace("{schemaName}", FormatIdentifier(options.SchemaName))
                .Replace("{tableName}", FormatIdentifier(options.TableName))
                .Replace("{setList}", setList)
                .Replace("{whereList}", whereList);
            return result;
        }
    }
}