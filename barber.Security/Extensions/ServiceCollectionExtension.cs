using Microsoft.Extensions.DependencyInjection;

namespace barber.Security.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services)
        {
            services.AddSingleton<Services.IEncryptionService, Services.EncryptionService>();
            services.AddScoped<Services.IAuthenticationService, Services.AuthenticationService>();
            services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.ExpireTimeSpan = System.TimeSpan.FromMinutes(2); // TODO: add to config
                    options.SlidingExpiration = false;
                    // TODO: Other options?
                });
            services.AddCascadingAuthenticationState();
            return services;
        }
    }
}