using BirdsApi.Business;
using BirdsApiBusiness.Models;
using System;
using Xunit;

namespace Tests
{
    public class BirdsServiceTests
    {
        private readonly BirdService _birdsService;
         public BirdsServiceTests()
         {
             _birdsService = new BirdService();
         }

        [Fact]
        public void PersistBird_ShouldThrow_When_ModelIsNotValid()
        {
            var invalidModel = new BirdDto();
            Assert.Throws<ArgumentException>(() => _birdsService.PersistBird(invalidModel));
        }
    }
}
