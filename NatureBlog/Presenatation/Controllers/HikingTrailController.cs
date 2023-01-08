using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Destinations.HikingTrails.Commands.UpdateDuration;
using NatureBlog.Application.App.Destinations.HikingTrails.Queries.GetHikingTrailInfo;
using NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Domain.Models;
using NatuteBlog.Application.Destinations.HikingTrails.Queries.FilterHikingTrails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NatureBlog.Presenatation.Controllers
{
    [Route("api/destination/hiking-trails")]
    [ApiController]
    public class HikingTrailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HikingTrailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHikingTrails()
        {
            var result = await _mediator.Send(new GetAllHikingTrailsQuery());

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetHikingTrail(int id)
        {
            var result = await _mediator.Send(new GetHikingTrailInfoQuery { Id = id });

            if (result is null)
                return NotFound();

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
                //Ratings = new ICollection<Rating> { },
                Difficulty = hikingTrail.Difficulty,
                Duration = hikingTrail.Duration
            });

            if (result is null)
                return BadRequest("Invalid input");

            return Ok(result);
        }

        [HttpPut("difficulty/{id}")]
        public async Task<IActionResult> UpdateDifficulty(int id, [FromBody] HikingTrailDifficultyPostDto hikingTrail)
        {
            var result = await _mediator.Send(new UpdateDifficultyCommand
            {
                DestinationId = id,
                UserId = hikingTrail.UserId,
                Difficulty = hikingTrail.Difficulty,
            });

            if (result is null)
                return BadRequest("Icorect input or user is not creator!");

            return Ok("Difficulty sucessfully modified!");
        }

        [HttpPut]
        [Route("duration/{id}")]
        public async Task<IActionResult> UpdateDuration(int id, [FromBody] HikingTrailDurationPutDto hikingTrailInfo)
        {
            var result = await _mediator.Send(new UpdateDurationCommand
            {
                DestinationId = id,
                UserId = hikingTrailInfo.UserId,
                HikingDuration = hikingTrailInfo.HikingDuration
            });

            if(result is null) 
                return BadRequest("Incorrect input!");
            if (result == false)
                return StatusCode(500);

            return Ok(result);
        }
        [HttpGet]
        [Route("filter-by-difficulty/{difficulty}")]
        public async Task<IActionResult> GetFilteredHikingTrails(int difficulty)
        {
            var result = await _mediator.Send(new FilterHikingTrailsQuery{ Difficulty = difficulty });

            if (result.Count == 0) return NoContent();

            return Ok(result);
        }
    }
}
