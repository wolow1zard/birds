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
        
        /// <summary>
        /// Lists the id for all visible birds
        /// </summary>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(List<string>))]
        public List<string> GetBirds()
        {
            return _birdService.GetAllVisibleBirds();
        }
        
        /// <summary>
        /// Get details on a specific bird. Even birds with visible=false are returned.
        /// </summary>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(BirdPersistedDto))]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
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
        /// The id of the newly created bird
        /// </summary>
        [SwaggerResponse(HttpStatusCode.OK, type: typeof(string))]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
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
        [SwaggerResponse(HttpStatusCode.BadRequest)]
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
        
        /// <summary>
        /// Deletes a bird by id
        /// </summary>
        [SwaggerResponse(HttpStatusCode.OK)]
        [SwaggerResponse(HttpStatusCode.BadRequest)]
        [SwaggerResponse(HttpStatusCode.NotFound)]
        public IHttpActionResult Delete(string birdId)
        {
            if (!string.IsNullOrWhiteSpace(birdId))
            {
                try
                {
                    _birdService.DeleteBird(birdId);
                    return Ok();
                }
                catch (KeyNotFoundException)
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
