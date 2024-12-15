namespace barber.Security.Services
{
    public interface IAuthenticationService
    {
        System.Threading.Tasks.Task<bool> AuthenticateAsync(Microsoft.AspNetCore.Http.HttpContext context, string username, string password);
    }
}