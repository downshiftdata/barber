using Microsoft.Extensions.DependencyInjection;

namespace barber.Data.Sql.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddData(this IServiceCollection services)
        {
            services.AddSingleton<Models.ISqlContext, Models.SqlContext>();
            services.AddSingleton<Interfaces.IExecuteService, Services.ExecuteService>();
            services.AddSingleton<Interfaces.IQueryService, Services.QueryService>();
            services.AddSingleton<Interfaces.ICommandService, Services.CommandService>();
            return services;
        }
    }
}