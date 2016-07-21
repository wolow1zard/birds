using System.Collections.Generic;
using BirdsApi.Models;

namespace BirdsApi.Business
{
    public interface IBirdService
    {
        List<string> GetAllVisibleBirds();
        BirdPersistedDto GetBird(string birdId);
        void DeleteBird(string birdId);
        void PersistBird(BirdDto birdDto);
        void UpdateBird(int birdId, BirdDto birdDto);
    }
}