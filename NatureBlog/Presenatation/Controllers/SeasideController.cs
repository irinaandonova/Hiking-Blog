using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside;
using NatureBlog.Application.Dto.Destination.Seaside;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presenatation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeasideController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeasideController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<SeasideController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeaside([FromBody] SeasidePostDto seaside)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateSeasideCommand
            {
                Name = seaside.Name,
                CreatorId = seaside.CreatorId,
                RegionId = seaside.RegionId,
                Description = seaside.Description,
                ImageUrl = seaside.ImageUrl,
                OffersUmbrella = seaside.OffersUmbrella,
                IsGuarded = seaside.IsGuarded
            });

            return Ok(result);
        }

        // POST api/<SeasideController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeasideController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SeasideController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
