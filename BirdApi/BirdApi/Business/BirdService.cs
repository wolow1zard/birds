using System.Collections.Generic;
using System.Linq;
using BirdsApi.Models;
using MongoDB.Driver;
using MongoDB.Bson;
using AutoMapper;
using System;

namespace BirdsApi.Business
{
    public class BirdService : IBirdService
    {
        private readonly IMongoCollection<BirdMongo> _collection;
        public BirdService(IMongoCollection<BirdMongo> collection)
        {
            _collection = collection;
        }

        public List<string> GetAllVisibleBirds()
        {
            return _collection.AsQueryable().Where(b=> b.Visible).Select(b => b.Id).ToList().Select(o => o.ToString()).ToList();
        }

        public BirdPersistedDto GetBird(string birdId)
        {
            if (string.IsNullOrEmpty(birdId))
            {
                throw new ArgumentException(nameof(birdId));
            }

            var oId = new ObjectId(birdId);
            return Mapper.Map<BirdPersistedDto>(_collection.AsQueryable().SingleOrDefault(b => b.Id == oId));
        }

        public string PersistBird(BirdDto birdDto)
        {
            if (birdDto == null)
            {
                throw new ArgumentNullException(nameof(birdDto));
            }

            var d = Mapper.Map<BirdMongo>(birdDto);
            _collection.InsertOne(d);
            return d.Id.ToString();
        }

        public void UpdateBird(string birdId, BirdDto birdDto)
        {
            var filter = new BsonDocument("_id", new ObjectId(birdId));
            var update = new BsonDocument("$set", birdDto.ToBsonDocument());
            var result = _collection.UpdateOne(filter, update);
        }
        public void DeleteBird(string birdId)
        {
            var filter = new BsonDocument("_id", new ObjectId(birdId));
            var result = _collection.FindOneAndDelete(filter);
            if (result == null)
            {
                throw new KeyNotFoundException("Bird does not exist!");
            }
        }
    }
}
