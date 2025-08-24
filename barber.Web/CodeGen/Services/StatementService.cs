namespace barber.CodeGen.Services
{
    public class StatementService : IStatementService
    {
        private Builders.IStatementTextBuilder _Builder;

        public StatementService(Builders.IStatementTextBuilder builder)
        {
            _Builder = builder;
        }

        public string? GetStatementText(Data.Models.StatementRequest request)
        {
            switch (request.StatementType)
            {
                case Core.Enum.StatementType.None:
                    return null;
                case Core.Enum.StatementType.Custom:
                    return request.StatementText;
                case Core.Enum.StatementType.Insert:
                    return _Builder.BuildInsert(new Models.StatementBuilderOptions()
                    {
                        StatementType = request.StatementType,
                        SchemaName = request.SchemaName ?? throw new System.ArgumentNullException("SchemaName"),
                        TableName = request.TableName ?? throw new System.ArgumentNullException("TableName"),
                        Parameters = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.IEnumerable<Models.StatementParameter>>(request.StatementDetailJson
                                ?? throw new System.ArgumentNullException("StatementDetailJson"))
                            ?? throw new System.ArgumentException("StatementDetailJson")
                    });
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}