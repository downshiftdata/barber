using Microsoft.Extensions.DependencyInjection;

namespace barber.Data.Sql.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddSingleton<Models.ISqlContext, Models.SqlContext>();
            services.AddSingleton<Interfaces.IExecuteRepository, Repositories.ExecuteRepository>();
            services.AddSingleton<Interfaces.IReadRepository, Repositories.ReadRepository>();
            services.AddSingleton<Interfaces.IWriteRepository, Repositories.WriteRepository>();
            return services;
        }
    }
}