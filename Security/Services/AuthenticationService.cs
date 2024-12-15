using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;

namespace barber.Security.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IEncryptionService _EncryptionService;
        private readonly ILogger _Logger;
        private readonly Data.Repositories.IReadRepository _ReadRepository;

        public AuthenticationService(IEncryptionService encryptionService, Data.Repositories.IReadRepository readRepository, ILogger<AuthenticationService> logger)
        {
            _EncryptionService = encryptionService;
            _ReadRepository = readRepository;
            _Logger = logger;
        }

        public async System.Threading.Tasks.Task<bool> AuthenticateAsync(Microsoft.AspNetCore.Http.HttpContext context, string userName, string password)
        {
            var passwordHash = _EncryptionService.OneWayEncrypt(password);
            _Logger.LogWarning(passwordHash);
            var user = await _ReadRepository.SelectUserByCredentials(userName, passwordHash);
            if (user == null) return false;
            var claims = new System.Collections.Generic.List<System.Security.Claims.Claim>()
            {
                new(System.Security.Claims.ClaimTypes.Name, user.UserName)
            };
            if (user.IsAdmin) claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, Roles.Admin));
            if (user.IsApprover) claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, Roles.Approver));
            if (user.IsEditor) claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, Roles.Editor));
            if (user.IsExecutor) claims.Add(new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, Roles.Executor));
            var identity = new System.Security.Claims.ClaimsIdentity(claims, Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);
            await context.SignInAsync(principal);
            _Logger.LogInformation("User {userName} authenticated.", userName);
            return true;
        }
    }
}