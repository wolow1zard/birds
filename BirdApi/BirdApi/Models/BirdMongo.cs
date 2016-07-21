using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace BirdsApi.Models
{
    public class BirdMongo
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public List<string> Continents { get; set; }
        public bool Visible { get; set; }
    }
}
