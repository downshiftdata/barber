using Microsoft.Extensions.Configuration;
using _ssc = System.Security.Cryptography;

namespace barber.Security.Services
{
    public class SecurityService : ISecurityService
    {
        public const string PasswordHash = "5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8";

        private const string SettingsSectionName = "Security";

        private readonly Models.SecuritySettings _Settings;

        public SecurityService(IConfiguration configuration)
        {
            _Settings = configuration.GetSection(SettingsSectionName).Get<Models.SecuritySettings>() ?? new Models.SecuritySettings();
        }

        public string Decrypt(string value)
        {
            if (string.IsNullOrWhiteSpace(_Settings.AesKey)) throw new System.ArgumentNullException("AesKey");
            if (string.IsNullOrWhiteSpace(_Settings.AesIv)) throw new System.ArgumentNullException("AesIv");
            if (string.IsNullOrWhiteSpace(value)) throw new System.ArgumentNullException(nameof(value));

            using (_ssc.Aes aes = _ssc.Aes.Create())
            {
                aes.Key = System.Text.Encoding.ASCII.GetBytes(_Settings.AesKey);
                aes.IV = System.Text.Encoding.ASCII.GetBytes(_Settings.AesIv);
                aes.Padding = _ssc.PaddingMode.PKCS7;

                _ssc.ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (System.IO.MemoryStream memoryStream = new (System.Text.Encoding.ASCII.GetBytes(value)))
                {
                    using (_ssc.CryptoStream cryptoStream = new (memoryStream, decryptor, _ssc.CryptoStreamMode.Read))
                    {
                        using (System.IO.StreamReader streamReader = new (cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string Encrypt(string value)
        {
            if (string.IsNullOrWhiteSpace(_Settings.AesKey)) throw new System.ArgumentNullException("AesKey");
            if (string.IsNullOrWhiteSpace(_Settings.AesIv)) throw new System.ArgumentNullException("AesIv");
            if (string.IsNullOrWhiteSpace(value)) throw new System.ArgumentNullException(nameof(value));

            using (_ssc.Aes aes = _ssc.Aes.Create())
            {
                aes.Key = System.Text.Encoding.ASCII.GetBytes(_Settings.AesKey);
                aes.IV = System.Text.Encoding.ASCII.GetBytes(_Settings.AesIv);
                aes.Padding = _ssc.PaddingMode.PKCS7;

                _ssc.ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                var bytes = System.Text.Encoding.ASCII.GetBytes(value);
                using (System.IO.MemoryStream memoryStream = new ())
                {
                    using (_ssc.CryptoStream cryptoStream = new (memoryStream, encryptor, _ssc.CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter streamWriter = new (cryptoStream))
                        {
                            streamWriter.Write(bytes);
                        }
                        return System.Text.Encoding.ASCII.GetString(memoryStream.ToArray());
                    }
                }
            }
        }

        public string OneWayEncrypt(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new System.ArgumentNullException(nameof(value));

            using (_ssc.SHA256 sha = _ssc.SHA256.Create())
            {
                var bytes = System.Text.Encoding.ASCII.GetBytes(value);
                var result = sha.ComputeHash(bytes);
                return System.Text.Encoding.ASCII.GetString(result);
            }
        }
    }
}