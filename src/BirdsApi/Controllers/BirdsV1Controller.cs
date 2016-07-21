using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BirdsApi.Models;
using BirdsApi.Business;

namespace BirdsApi.Controllers
{
    [Route("v1")]
    public class BirdsV1Controller : Controller
    {
        private readonly IBirdService _birdService;

        public BirdsV1Controller(IBirdService birdService)
        {
            _birdService = birdService;
        }

        [HttpGet("birds")]
        public List<string> Get()
        {
            return _birdService.GetAllVisibleBirds();
        }
        
        [HttpGet("birds/{birdId}")]
        public BirdPersistedDto Get(string birdId)
        {
            return _birdService.GetBird(birdId);
        }

        [HttpPost("birds")]
        public void Post([FromBody] BirdDto birdDto)
        {
            _birdService.PersistBird(birdDto);
        }


        [HttpPut("birds/{birdId}")]
        public void Put(int birdId, [FromBody] BirdDto birdDto)
        {
            _birdService.UpdateBird(birdId, birdDto);
        }

        [HttpDelete("birds/{birdId}")]
        public void Delete(string birdId)
        {
            _birdService.DeleteBird(birdId);
        }
    }
}
