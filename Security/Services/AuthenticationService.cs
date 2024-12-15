using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace barber.Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ILogger _Logger;

        public AuthenticationService(ILogger<AuthenticationService> logger)
        {
            _Logger = logger;
        }

        public async System.Threading.Tasks.Task AuthenticateAsync(Microsoft.AspNetCore.Http.HttpContext context, string userName, string password)
        {
            //TODO: Authenticate via repository
            var claims = new System.Collections.Generic.List<System.Security.Claims.Claim>()
            {
                new(System.Security.Claims.ClaimTypes.Name, userName),
                new(System.Security.Claims.ClaimTypes.Role, "Admin")
            };
            var identity = new System.Security.Claims.ClaimsIdentity(claims, Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);
            await context.SignInAsync(principal);
            _Logger.LogInformation("User {userName} authenticated.", userName);
        }
    }
}