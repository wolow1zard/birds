
using System;
using System.Collections.Generic;
using System.Linq;
using BirdsApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace BirdsApi.Business
{
    public class BirdService : IBirdService
    {
        private readonly IMongoCollection<BsonDocument> _collection;
        public BirdService()
        {
             var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("birdapi");
            _collection = database.GetCollection<BsonDocument>("birds");
        }

        public List<string> GetAllVisibleBirds()
        {
            var documents = _collection.Find(new BsonDocument()).ToList();
            var l = new List<string>();
            foreach (var document in documents)
            {
                l.Add(((ObjectId)document.ToDictionary()["_id"]).ToString());
            }
            return l;
        }

        public BirdPersistedDto GetBird(string birdId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", birdId);
            var document = _collection.Find(filter).First();

            if (document != null)
            {
                
            }
            return null;
        }

        public void PersistBird(BirdDto birdDto)
        {
            if (!birdDto.HasValidState())
            {
                throw new ArgumentException("invalid model!");
            }

            _collection.InsertOne(birdDto.ToBsonDocument());
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
