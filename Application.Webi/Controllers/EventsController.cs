using Application.Interface;
using Application.Model;
using Application.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;

namespace Application.Webi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEvents _repository;
        public EventsController(IEvents repository)
        {
            _repository = repository;
        }

        [HttpGet("Events")]
        [SwaggerOperation]
        public async Task<ActionResult<IEnumerable<Events>>> GetAll()
        {
            var users = await _repository.GetAllEvents();
            return Ok(users);
        }

        [HttpGet("Delete/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult<Events>> Delete(Events e)
        {
            _repository.Delete(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        //api/Users/3
        [HttpGet("GetById/Id")]
        [SwaggerOperation]
        public async Task<ActionResult<Events>> GetBydId(int Id)
        {
            return await _repository.GetEventById(Id);

        }

        [HttpPut("Update/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult> Update(Events e)
        {

            _repository.Put(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }

        [HttpPost("Post/{Model}")]
        [SwaggerOperation]
        public async Task<ActionResult> Post(Events e)
        {

            _repository.Post(e);
            if (await _repository.SaveAllAsync()) return NoContent();

            return BadRequest("Failed to update user");
        }
    }
}
