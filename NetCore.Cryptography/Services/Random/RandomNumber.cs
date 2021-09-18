using System;
using System.Security.Cryptography;

namespace NetCore.Cryptography.Services.Random
{
    public class RandomNumber
    {
        public static byte[] Generate(int lengh)
        {
            using var randomNumber = new RNGCryptoServiceProvider();

            var random = new byte[lengh];
            randomNumber.GetBytes(random);

            return random;
        }
    }
}
