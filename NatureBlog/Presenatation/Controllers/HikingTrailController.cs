using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Destinations.HikingTrails.Queries.GetHikingTrailInfo;
using NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatuteBlog.Application.Destinations.HikingTrails.Queries.FilterHikingTrails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NatureBlog.Presenatation.Controllers
{
    [Route("api/destination/[controller]")]
    [ApiController]
    public class HikingTrailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HikingTrailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllHikingTrails()
        {
            var result = _mediator.Send(new GetAllHikingTrailsQuery());

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetHikingTrail(int id)
        {
            var result = _mediator.Send(new GetHikingTrailInfoQuery { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHikingTrail([FromBody] HikingTrailPostDto hikingTrail)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateHikingTrailCommand
            {
                Name = hikingTrail.Name,
                CreatorId = hikingTrail.CreatorId,
                RegionId = hikingTrail.RegionId,
                Description = hikingTrail.Description,
                ImageUrl = hikingTrail.ImageUrl,
                Difficulty = hikingTrail.Difficulty,
                Duration = hikingTrail.Duration
            });

            if (result is null)
                return BadRequest("Invalid input");

            return Ok(result);
        }

        [HttpPut("difficulty/{id}")]
        public async Task<IActionResult> ChangeDifficulty(int id, [FromBody] HikingTrailDifficultyPostDto hikingTrail)
        {
            var result = await _mediator.Send(new ChangeDifficultyCommand
            {
                DestinationId = id,
                UserId = hikingTrail.UserId,
                Difficulty = hikingTrail.Difficulty,
            });

            if (!result)
                return BadRequest();

            return Ok();
        }

        [HttpGet]
        [Route("filter-by-difficulty/{difficulty}")]
        public async Task<IActionResult> GetFilteredHikingTrails(int difficulty)
        {
            var result = await _mediator.Send(new FilterHikingTrailsQuery{ Difficulty = difficulty });

            if (result.Count == 0) return Ok("No such hiking trails");
            return Ok(result);
        }

    }
}
