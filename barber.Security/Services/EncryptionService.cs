using Microsoft.Extensions.Configuration;
using barber.Core.Extensions;
using _ssc = System.Security.Cryptography;

namespace barber.Security.Services
{
    public class EncryptionService : IEncryptionService
    {
        private const string SettingsSectionName = "Security";

        private readonly Models.SecuritySettings _Settings;

        public EncryptionService(IConfiguration configuration)
        {
            _Settings = configuration.GetSection(SettingsSectionName).Value.FromJson(new Models.SecuritySettings());
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

                using (System.IO.MemoryStream memoryStream = new (System.Convert.FromBase64String(value)))
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

                //var bytes = System.Text.Encoding.ASCII.GetBytes(value);
                using (System.IO.MemoryStream memoryStream = new ())
                {
                    using (_ssc.CryptoStream cryptoStream = new (memoryStream, encryptor, _ssc.CryptoStreamMode.Write))
                    {
                        using (System.IO.StreamWriter streamWriter = new (cryptoStream))
                        {
                            streamWriter.Write(value);
                        }
                        return System.Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
        }

        public string OneWayEncrypt(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new System.ArgumentNullException(nameof(value));

            var bytes = System.Text.Encoding.ASCII.GetBytes(value);
            var result = _ssc.SHA256.HashData(bytes);;
            return System.Convert.ToBase64String(result);
        }
    }
}