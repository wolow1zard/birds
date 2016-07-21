using System;
using BirdsApi.Business;
using NUnit.Framework;

namespace BirdApi.Tests.Business
{
    [TestFixture]
    public class BirdServiceTests
    {
        [Test]
        public void Should_ThrowNullException_When_PersistingNull()
        {
            // Arrange
            var service = new BirdService();

            // Act/Assert
            Assert.Throws<NullReferenceException>(() => service.PersistBird(null));
        }
    }
}
