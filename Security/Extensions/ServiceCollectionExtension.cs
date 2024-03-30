using Microsoft.Extensions.DependencyInjection;

namespace barber.Security.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddSingleton<Services.ISecurityService, Services.SecurityService>();
            return services;
        }
    }
}