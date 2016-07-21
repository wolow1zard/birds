using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using BirdsApi.Models;
using BirdsApi.Business;
using Swashbuckle.Swagger.Annotations;

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
        
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(BirdPersistedDto))]
        public IHttpActionResult GetBird(string birdId)
        {
            if (!string.IsNullOrWhiteSpace(birdId))
            {
                var result = _birdService.GetBird(birdId);
                if (result != null)
                {
                    return this.Ok(result);
                }
                return NotFound();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="birdDto"></param>
        /// <returns>The id of the newly created bird</returns>
        /// 
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(string))]
        public IHttpActionResult Post([FromBody] BirdDto birdDto)
        {
            if (birdDto.HasValidState())
            {
                var id = _birdService.PersistBird(birdDto);
                return this.Created($"/birds/{id}", id);
            }
            else
            {
                return BadRequest();
            }
        }
        
        
        [SwaggerResponse(HttpStatusCode.OK)]
        public IHttpActionResult Put(string birdId, [FromBody] BirdDto birdDto)
        {
            if (birdDto.HasValidState())
            {
                _birdService.UpdateBird(birdId, birdDto);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        
        
        [SwaggerResponse(HttpStatusCode.OK)]
        public IHttpActionResult Delete(string birdId)
        {
            if (!string.IsNullOrWhiteSpace(birdId))
            {
                _birdService.DeleteBird(birdId);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
