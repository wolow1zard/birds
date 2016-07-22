using System;
using BirdsApi.Business;
using BirdsApi.Models;
using MongoDB.Driver;
using NUnit.Framework;
using BirdApi.Tests.Builders;
using MongoDB.Bson.Serialization;

namespace BirdApi.Tests.Business
{
    [TestFixture]
    public class BirdServiceTests
    {
        private BirdService GetBirdService()
        {
            return new BirdService(
                new MongoClient(System.Configuration.ConfigurationManager.AppSettings["mongodbconnection"]).
                    GetDatabase("birdapi").
                    GetCollection<BirdMongo>("birds")
                );
        }

        [Test]
        public void Should_ThrowNullException_When_PersistingNull()
        {
            // Arrange
            var service = GetBirdService();
            

            // Act/Assert
            Assert.Throws<ArgumentNullException>(() => service.PersistBird(null));
        }

        [Test]
        public void Should_BePartOfBirds_AfterCreation()
        {
            // Arrange
            var service = GetBirdService();
            var model = new BirdDtoBuilder()
            {
                _visible = true
            }.Build();

            // Act
            var id = service.PersistBird(model);
            var actual = service.GetAllVisibleBirds();
            
            //Assert
            Assert.True(actual.Contains(id));
        }

        [Test]
        public void Should_NotBePartOfBirds_AfterCreation_WhenVisibleIsFalse()
        {
            // Arrange
            var service = GetBirdService();
            var model = new BirdDtoBuilder()
            {
                _visible = false
            }.Build();

            // Act
            var id = service.PersistBird(model);
            var actual = service.GetAllVisibleBirds();
            
            //Assert
            Assert.False(actual.Contains(id));
        }

        [Test]
        public void Should_BeAvailable_AfterCreation()
        {
            // Arrange
            var service = GetBirdService();
            var expected = new BirdDtoBuilder()
            {
                _visible = true
            }.Build();

            // Act
            var id = service.PersistBird(expected);
            var actual = service.GetBird(id);
            
            //Assert
            Assert.AreEqual(expected.Visible, actual.Visible);
            Assert.AreEqual(expected.Family, actual.Family);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.That(expected.Continents, Is.EquivalentTo(actual.Continents));
        }
    }
}
