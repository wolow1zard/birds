
using System;
using System.Collections.Generic;
using System.Linq;
using BirdsApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using AutoMapper;

namespace BirdsApi.Business
{
    public class BirdService : IBirdService
    {
        private readonly IMongoCollection<BirdMongo> _collection;
        public BirdService()
        {
             var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("birdapi");
            _collection = database.GetCollection<BirdMongo>("birds");
        }

        public List<string> GetAllVisibleBirds()
        {
            return _collection.AsQueryable().Where(b=> b.Visible).Select(b => b.Id).ToList().Select(o => o.ToString()).ToList();
        }

        public BirdPersistedDto GetBird(string birdId)
        {
            var oId = new ObjectId(birdId);
            return Mapper.Map<BirdPersistedDto>(_collection.AsQueryable().SingleOrDefault(b => b.Id == oId));
        }

        public string PersistBird(BirdDto birdDto)
        {
            var d = Mapper.Map<BirdMongo>(birdDto);
            _collection.InsertOne(d);
            return d.Id.ToString();
        }

        public void UpdateBird(string birdId, BirdDto birdDto)
        {
            var filter = new BsonDocument("_id", new ObjectId(birdId));
            //var update = new BsonDocument("$set", 
            var update = new BsonDocument("$set", birdDto.ToBsonDocument());
            var result = _collection.UpdateOne(filter, update);
        }
        public void DeleteBird(string birdId)
        {
            var filter = new BsonDocument("_id", new ObjectId(birdId));
            var result = _collection.FindOneAndDelete(filter);
            if (result == null)
            {
                throw new ArgumentException("Bird does not exist!");
            }
        }
    }
}
