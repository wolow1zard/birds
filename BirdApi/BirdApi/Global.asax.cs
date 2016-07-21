using System.Web.Http;
using AutoMapper;
using BirdsApi.Models;

namespace BirdApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();


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
