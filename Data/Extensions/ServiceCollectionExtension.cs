using Microsoft.Extensions.DependencyInjection;

namespace barber.Data.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddSingleton<Models.ISqlContext, Models.SqlContext>();
            services.AddSingleton<Repositories.IReadRepository, Repositories.ReadRepository>();
            services.AddSingleton<Repositories.IWriteRepository, Repositories.WriteRepository>();
            return services;
        }
    }
}