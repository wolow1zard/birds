using BirdsApi.Models;
using NUnit.Framework;
using MongoDB.Bson.Serialization;
using AutoMapper;

namespace BirdApi.Tests.Business
{
    [SetUpFixture]
    public class Setups
    {
        [ OneTimeSetUp ]
        public void StartUp()
        {
            BsonClassMap.RegisterClassMap<BirdPersistedDto>(m => 
            {
                m.AutoMap();
            });

            BsonClassMap.RegisterClassMap<BirdDto>(m => 
            {
                m.AutoMap();
            });

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BirdDto, BirdMongo>();
                cfg.CreateMap<BirdMongo, BirdPersistedDto>()
                    .ForMember(ev => ev.Id, m => m.MapFrom(a => a.Id.ToString()))
                    .ForMember(ev => ev.Added, m => m.MapFrom(a => a.Id.CreationTime.ToString("yyyy-MM-dd")));
            });
        }
    }
}
