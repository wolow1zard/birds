using Microsoft.AspNetCore.Mvc;

namespace BirdsApi.Controllers
{
    [Route("")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SwaggerRedirectController : Controller
    {
        // GET api/values
        [HttpGet]
        public RedirectResult Index()
        {
            return new RedirectResult("/swagger/ui/index.html");
        }
    }
}
