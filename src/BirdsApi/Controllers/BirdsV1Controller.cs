using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BirdsApiBusiness.Models;
using BirdsApi.Business;

namespace BirdsApi.Controllers
{
    [Route("v1")]
    public class BirdsV1Controller : Controller
    {
        private readonly IBirdService _birdService;
        private const int BadRequestStatusCode = 400;

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
            if (!string.IsNullOrWhiteSpace(birdId))
            {
                return _birdService.GetBird(birdId);
            }
            else
            {
                Response.StatusCode = BadRequestStatusCode;
                return null;
            }
        }

        [HttpPost("birds")]
        public void Post([FromBody] BirdDto birdDto)
        {
            if (birdDto.HasValidState())
            {
                _birdService.PersistBird(birdDto);
            }
            else
            {
                Response.StatusCode = BadRequestStatusCode;
            }
        }


        [HttpPut("birds/{birdId}")]
        public void Put(int birdId, [FromBody] BirdDto birdDto)
        {
            if (birdDto.HasValidState())
            {
                _birdService.UpdateBird(birdId, birdDto);
            }
            else
            {
                Response.StatusCode = BadRequestStatusCode;
            }
        }

        [HttpDelete("birds/{birdId}")]
        public void Delete(string birdId)
        {
            if (!string.IsNullOrWhiteSpace(birdId))
            {
                _birdService.DeleteBird(birdId);
            }
            else
            {
                Response.StatusCode = BadRequestStatusCode;
            }
        }
    }
}
