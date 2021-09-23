using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore.Cryptography.Services.Encryption;
using NetCore.Cryptography.Services.Random;

namespace NetCore.Cryptography.Tests.Services.Encryption
{
    [TestClass]
    public class AesTests
    {
        [TestMethod]
        public void DecryptAsync_ShouldReturnOriginalData_WhenSameDataKeyIv()
        {
            // Arrange
            byte[] iv = RandomNumber.Generate(16);
            byte[] key = RandomNumber.Generate(32);
            byte[] data = Encoding.UTF8.GetBytes("Secret message to encrypt");
            var sut = new Aes();

            // Act
            var encryptedMessage = sut.EncriptAsync(data, key, iv);
            encryptedMessage.Wait();
            var decriptedMessage = sut.DecriptAsync(encryptedMessage.Result, key, iv);
            decriptedMessage.Wait();

            // Assert
            Assert.AreEqual(Convert.ToBase64String(data), Convert.ToBase64String(decriptedMessage.Result));
        }
    }
}
