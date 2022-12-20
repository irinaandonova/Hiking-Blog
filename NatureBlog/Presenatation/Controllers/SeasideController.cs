using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.Destinations.Parks.Queries.GetAllPark;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside;
using NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside;
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

        [HttpGet]
        public IActionResult GetAllSeaside()
        {
            var result = _mediator.Send(new GetAllSeasidesQuery());

            if (result == null)
            {
                return NotFound();
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

            return Ok(result);
        }
    }
}
