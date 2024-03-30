namespace barber.Security.Services
{
    public interface ISecurityService
    {
        string Decrypt(string value);
        string Encrypt(string value);
    }
}