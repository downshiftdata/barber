namespace barber.Security.Services
{
    public interface IAuthenticationService
    {
        System.Threading.Tasks.Task<bool> SignInAsync(Microsoft.AspNetCore.Http.HttpContext context, string username, string password);

        System.Threading.Tasks.Task<bool> SignOutAsync(Microsoft.AspNetCore.Http.HttpContext context);
    }
}