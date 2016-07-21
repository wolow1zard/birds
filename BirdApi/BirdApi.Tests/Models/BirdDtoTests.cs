using BirdsApi.Models;
using NUnit.Framework;

namespace BirdApi.Tests.Business
{
    [TestFixture]
    public class BirdDtoTests
    {
        [Test]
        public void Should_BeVisibleByDefault()
        {
            // Arrange
            var model = new BirdDto();

            // Assert
            Assert.AreEqual(false, model.Visible);
        }
    }
}
