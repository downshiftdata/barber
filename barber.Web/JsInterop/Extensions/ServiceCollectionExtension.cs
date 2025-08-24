using Microsoft.Extensions.DependencyInjection;

namespace barber.JsInterop.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddJsInterop(this IServiceCollection services)
        {
            services.AddScoped<Services.ILocalStorageService, Services.LocalStorageService>();
            return services;
        }
    }
}