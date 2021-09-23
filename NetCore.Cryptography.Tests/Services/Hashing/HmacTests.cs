using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore.Cryptography.Services.Random;
using NetCore.Cryptography.Services.Hashing;
using System.Text;

namespace NetCore.Cryptography.Tests.Services.Hashing
{
    [TestClass]
    public class HmacTests
    {
       [TestMethod]
       public void ComputeHmac256_ShouldReturnSameResutl_WhenSameDataAndKey()
       {
            // Arrange
            string textToHash = "Hello my friend";
            string key = Convert.ToBase64String(RandomNumber.Generate(32));
            var sut = new Hmac();

            // Act
            var result1 = sut.ComputeHmac256(Encoding.UTF8.GetBytes(textToHash), key);
            var result2 = sut.ComputeHmac256(Encoding.UTF8.GetBytes(textToHash), key);

            // Assert
            Assert.AreEqual(Convert.ToBase64String(result1), Convert.ToBase64String(result2));
       }

        [TestMethod]
        public void ComputeHmac256_ShouldReturnDiffResutl_WhenSameDataAndDiffKey()
        {
            // Arrange
            string textToHash = "Hello my friend";
            var sut = new Hmac();

            // Act
            var result1 = sut.ComputeHmac256(Encoding.UTF8.GetBytes(textToHash), "key1");
            var result2 = sut.ComputeHmac256(Encoding.UTF8.GetBytes(textToHash), "key2");

            // Assert
            Assert.AreNotEqual(Convert.ToBase64String(result1), Convert.ToBase64String(result2));
        }

        [TestMethod]
        public void ComputeHmac256WithRandomKey_ShouldReturnSameResult_WhenUsingTheGeneratedKeyToHashAgain()
        {
            // Arrange
            string dataToHash = "This is a very important data";
            byte[] data = Encoding.UTF8.GetBytes(dataToHash);
            var sut = new Hmac();

            // Act
            (var resultHash, var key) = sut.ComputeHmac256WithRandomKey(data);
            var resultHashAgain = sut.ComputeHmac256(data, key);

            // Assert
            Assert.AreEqual(Convert.ToBase64String(resultHash), Convert.ToBase64String(resultHashAgain));
        }
    }
}
