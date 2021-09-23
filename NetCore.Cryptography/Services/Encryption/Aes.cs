using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NetCore.Cryptography.Services.Encryption
{
    public class Aes
    {
        public async Task<byte[]> EncriptAsync(byte[] data, byte[] key, byte[] iv)
        {
            using var aes = new AesCryptoServiceProvider();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);

            await cryptoStream.WriteAsync(data, 0, data.Length);
            await cryptoStream.FlushFinalBlockAsync();

            return memoryStream.ToArray();
        }

        public async Task<byte[]> DecriptAsync(byte[] data, byte[] key, byte[] iv)
        {
            using var aes = new AesCryptoServiceProvider();

            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;

            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);

            await cryptoStream.WriteAsync(data, 0, data.Length);
            await cryptoStream.FlushFinalBlockAsync();

            return memoryStream.ToArray();
        }
    }
}
