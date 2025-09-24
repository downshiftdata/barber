using System.Linq;

namespace barber.CodeGen.Services
{
    public class StatementService : IStatementService
    {
        private System.Collections.Generic.IEnumerable<Builders.IStatementBuilder> _Builders;

        public StatementService(System.Collections.Generic.IEnumerable<Builders.IStatementBuilder> builders)
        {
            _Builders = builders;
        }

        public string? Build(Data.Models.StatementRequest request)
        {
            var options = new Models.StatementBuilderOptions()
            {
                StatementType = request.StatementType,
                SchemaName = request.SchemaName ?? throw new System.ArgumentNullException("SchemaName"),
                TableName = request.TableName ?? throw new System.ArgumentNullException("TableName"),
                Parameters = System.Text.Json.JsonSerializer.Deserialize<System.Collections.Generic.IEnumerable<Models.StatementParameter>>(request.StatementDetailJson
                            ?? throw new System.ArgumentNullException("StatementDetailJson"))
                        ?? throw new System.ArgumentException("StatementDetailJson")
            };
            var builder = _Builders.FirstOrDefault(b => b.StatementType == request.StatementType);
            return builder?.Build(options);
        }
    }
}