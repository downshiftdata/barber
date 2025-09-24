using Microsoft.Extensions.DependencyInjection;

namespace barber.CodeGen.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddCodeGen(this IServiceCollection services)
        {
            services.AddSingleton<Services.IStatementService, Services.StatementService>();
            services.AddSingleton<Builders.IStatementBuilder, Builders.InsertStatementBuilder>();
            return services;
        }
    }
}