using System.Collections.Generic;
using BirdsApi.Models;

namespace BirdsApi.Business
{
    public interface IBirdService
    {
        List<string> GetAllVisibleBirds();
        BirdPersistedDto GetBird(string birdId);
        void DeleteBird(string birdId);
        string PersistBird(BirdDto birdDto);
        void UpdateBird(string birdId, BirdDto birdDto);
    }
}