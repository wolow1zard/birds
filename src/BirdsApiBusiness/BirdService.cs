
using System;
using System.Collections.Generic;
using BirdsApiBusiness.Models;

namespace BirdsApi.Business
{
    public class BirdService : IBirdService
    {

        public List<string> GetAllVisibleBirds()
        {
            return new List<string>() {"bird1", "bird2"};
        }

        public BirdPersistedDto GetBird(string birdId)
        {
            if (birdId == "bird1")
            {
                return new BirdPersistedDto()
                {
                    Added = DateTime.Now.ToString("yyyy-MM-dd"),
                    Continents = new List<string>() {"Africa", "Asia"},
                    Visible = true,
                    Family = "family",
                    Id = "bird1",
                    Name = "birdeBird"
                };
            }
            else if (birdId == "bird2")
            {
                return new BirdPersistedDto()
                {
                    Added = DateTime.Now.ToString("yyyy-MM-dd"),
                    Continents = new List<string>() {"Africa", "Asia"},
                    Visible = true,
                    Family = "family",
                    Id = "bird2",
                    Name = "birdeBird"
                };
            }
            return null;
        }

        public void PersistBird(BirdDto birdDto)
        {
            if (!birdDto.HasValidState())
            {
                throw new ArgumentException("invalid model!");
            }
             // TODO implement
        }

        public void UpdateBird(int birdId, BirdDto birdDto)
        {
             // TODO implement
        }
        public void DeleteBird(string birdId)
        {
             // TODO implement
        }
    }
}
