using Microsoft.Owin;
using MongoDB.Bson.Serialization;
using Owin;
using System.Web.Http;
using BirdsApi.Models;
using AutoMapper;

[assembly: OwinStartup(typeof(BirdApi.Startup))]

namespace BirdApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);

            SwaggerConfig.Register();
             
            BsonClassMap.RegisterClassMap<BirdPersistedDto>(m => 
            {
                m.AutoMap();
            });

            BsonClassMap.RegisterClassMap<BirdDto>(m => 
            {
                m.AutoMap();
            });
            
        }
    }
}
