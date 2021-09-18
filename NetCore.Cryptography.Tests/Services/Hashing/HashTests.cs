using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore.Cryptography.Services.Hashing;
using NetCore.Cryptography.Services.Random;

namespace NetCore.Cryptography.Tests.Services.Hashing
{
    [TestClass]
    public class HashTests
    {
        [TestMethod]
        public void ComputeSHA256_ShouldReturnSameResult_WhenSameInput()
        {
            // Arrange
            string input1 = "This is the input";
            string input2 = "This is the input";

            // Act
            var hash = new Hash();
            var result1 = hash.ComputeSHA256(Encoding.UTF8.GetBytes(input1));
            var result2 = hash.ComputeSHA256(Encoding.UTF8.GetBytes(input2));

            // Assert
            Assert.AreEqual(Convert.ToBase64String(result1), Convert.ToBase64String(result2));
        }

        [TestMethod]
        public void HashPasswordWithSalt_ShouldReturnDistinctResult_WhenSameInputs()
        {
            // Arrange
            string password = "Very Strong password";
            Hash hash = new Hash();
            string paswordHash1;
            string salt1;
            string paswordHash2;
            string salt2;

            // Act
            (paswordHash1, salt1) = hash.HashPasswordWithRandomSalt(password);
            (paswordHash2, salt2) = hash.HashPasswordWithRandomSalt(password);

            // Arrange
            Assert.AreNotEqual(paswordHash1, paswordHash2);
            Assert.AreNotEqual(salt1, salt2);
        }

        [TestMethod]
        public void HashPasswordAndSalt_ShouldReturnSameResult_WhenSameSaltAndPassword()
        {
            // Arrange
            string password = "Very Strong password";
            var hash = new Hash();

            // Act
            (string passwordHash, string salt) = hash.HashPasswordWithRandomSalt(password);
            string passwordHash2 = hash.HashPasswordAndSalt(password, salt);

            // Assert
            Assert.AreEqual(passwordHash, passwordHash2);
        }

    }
}
