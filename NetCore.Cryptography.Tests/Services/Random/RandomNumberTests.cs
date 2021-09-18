using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetCore.Cryptography.Services.Random;

namespace NetCore.Cryptography.Tests.Services.Random
{
    [TestClass]
    public class RandomNumberTests
    {
        [TestMethod]
        public void Generate_ShouldGenerateRandomNumber_WhenValidLengh()
        {
            // Arrange
            int lengh = 128;

            // Act
            var first = RandomNumber.Generate(lengh);
            var second = RandomNumber.Generate(lengh);

            // Assert
            Assert.AreNotEqual(first, second);
        }
    }
}
