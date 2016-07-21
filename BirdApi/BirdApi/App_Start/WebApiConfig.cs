using System.Web.Http;

namespace BirdApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "API Default",
                routeTemplate: "{controller}",
                defaults: new { birdId = RouteParameter.Optional }
            );
            
            config.Routes.MapHttpRoute(
                name: "API Default2",
                routeTemplate: "{controller}/{birdId}",
                defaults: new { birdId = RouteParameter.Optional }
            );
        }
    }
}
