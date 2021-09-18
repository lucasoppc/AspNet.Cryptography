using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NetCore.Cryptography.Services.Random;

namespace NetCore.Cryptography.Services.Hashing
{
    public class Hash
    {

        public Hash()
        {

        }

        public byte[] ComputeSHA256(byte[] toBeHashed)
        {
            using var sha256 = SHA256.Create();

            return sha256.ComputeHash(toBeHashed);
        }

        public (string hash, string salt) HashPasswordWithRandomSalt(string password)
        {
            byte[] saltBytes = RandomNumber.Generate(32);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] passwordWithSalt = Combine(passwordBytes, saltBytes);
            byte[] hashBytes = ComputeSHA256(passwordWithSalt);

            string hash = Convert.ToBase64String(hashBytes);
            string salt = Convert.ToBase64String(saltBytes);

            return (hash, salt);
        }

        public string HashPasswordAndSalt(string password, string saltAsBase64String)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(saltAsBase64String);

            byte[] paswordAndSaltBytes = Combine(passwordBytes, saltBytes);
            byte[] hashBytes = ComputeSHA256(paswordAndSaltBytes);

            string hash = Convert.ToBase64String(hashBytes);

            return hash;
        }

        private byte[] Combine(byte[] first, byte[] second)
        {
            byte[] result = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, result, 0, first.Length);
            Buffer.BlockCopy(second, 0, result, first.Length, second.Length);

            return result;
        }
    }
}
