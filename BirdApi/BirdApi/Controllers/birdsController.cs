using System.Collections.Generic;
using System.Web.Http;
using BirdsApi.Models;
using BirdsApi.Business;

namespace BirdApi.Controllers
{
    public class birdsController : ApiController
    {
        
        private readonly IBirdService _birdService;

        public birdsController()
        {
            _birdService = new BirdService();
        }

        public birdsController(IBirdService service)
        {
            _birdService = service;
        }
        
        public List<string> GetBirds()
        {
            return _birdService.GetAllVisibleBirds();
        }
        
        
        public BirdPersistedDto GetBird(string birdId)
        {
            if (!string.IsNullOrWhiteSpace(birdId))
            {
                return _birdService.GetBird(birdId);
            }
            else
            {
                return null;
            }
        }

        public void Post([FromBody] BirdDto birdDto)
        {
            if (birdDto.HasValidState())
            {
                _birdService.PersistBird(birdDto);
            }
            else
            {
                //Response.StatusCode = BadRequestStatusCode;
            }
        }
        
        public void Put(int birdId, [FromBody] BirdDto birdDto)
        {
            if (birdDto.HasValidState())
            {
                _birdService.UpdateBird(birdId, birdDto);
            }
            else
            {
                //Response.StatusCode = BadRequestStatusCode;
            }
        }
        
        public void Delete(string birdId)
        {
            if (!string.IsNullOrWhiteSpace(birdId))
            {
                _birdService.DeleteBird(birdId);
            }
            else
            {
                //Response.StatusCode = BadRequestStatusCode;
            }
        }
    }
}
