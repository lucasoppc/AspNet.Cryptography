using System;
using System.Security.Cryptography;
using NetCore.Cryptography.Services.Random;

namespace NetCore.Cryptography.Services.Hashing
{
    public class Hmac
    {
        public (byte[] hashedData, string key) ComputeHmac256WithRandomKey(byte[] dataToHash)
        {
            byte[] keyBytes = RandomNumber.Generate(32);
            string key = Convert.ToBase64String(keyBytes);

            var hashedData = ComputeHmac256(dataToHash, key);

            return (hashedData, key);
        }

        public byte[] ComputeHmac256(byte[] dataToHash, string key)
        {
            byte[] keyBytes = Convert.FromBase64String(key);

            byte[] result = ComputeHmac256(dataToHash, keyBytes);

            return result;
        }

        public byte[] ComputeHmac256(byte[] dataToHash, byte[] key)
        {
            using var hmac = new HMACSHA256(key);

            byte[] result = hmac.ComputeHash(dataToHash);

            return result;
        }
    }
}
