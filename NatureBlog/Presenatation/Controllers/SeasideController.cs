using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside;
using NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside;
using NatureBlog.Application.Dto.Destination.Seaside;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NatureBlog.Presenatation.Controllers
{
    [Route("api/destination/[controller]")]
    [ApiController]
    public class SeasideController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SeasideController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSeaside()
        {
            var result = await _mediator.Send(new GetAllSeasidesQuery());

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
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
            if (result is null)
                return BadRequest();

            return Ok(result);
        }
        /*
        [HttpGet]
        [Route("filter/")]
        public async Task<IActionResult> FilterSeaside()*/
    }
}
