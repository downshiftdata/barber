using Microsoft.Extensions.DependencyInjection;

namespace barber.Statements.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddStatements(this IServiceCollection services)
        {
            services.AddSingleton<Builders.IStatementTextBuilder, Builders.StatementTextBuilder>();
            return services;
        }
    }
}