using Microsoft.AspNetCore.Mvc;

namespace BirdsApi.Controllers
{
    [Route("v1")]
    public class BirdsV1Controller : Controller
    {
        public BirdsV1Controller()
        {
        }

        /// <summary>
        /// Gets a testmodel with the given id, if no match is found an error is thrown
        /// </summary>
        [HttpGet("birds")]
        public string Get()
        {
            return "birds";
        }

        [HttpPost("birds")]
        public void Post(string webhookId)
        {
            // TODO implement
        }

        [HttpGet("birds/{birdId}")]
        public string Get(string birdId)
        {
             return "a bird";
             // TODO implement
        }

        [HttpPut("birds/{birdId}")]
        public void Put(int birdId)
        {
             // TODO implement
        }

        [HttpDelete("birds/{birdId}")]
        public void Delete(string birdId)
        {
            // TODO implement
        }
    }
}
