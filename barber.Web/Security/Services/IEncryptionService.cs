namespace barber.Security.Services
{
    public interface IEncryptionService
    {
        string Decrypt(string value);

        string Encrypt(string value);

        string OneWayEncrypt(string value);
    }
}