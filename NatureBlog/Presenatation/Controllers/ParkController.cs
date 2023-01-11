using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Destinations.Parks.Commands.UpdateHasPlaygroundField;
using NatureBlog.Application.App.Destinations.Parks.Queries.GetParkInfo;
using NatureBlog.Application.Destinations.Parks.Commands.CreatePark;
using NatureBlog.Application.Destinations.Parks.Queries.GetAllPark;
using NatureBlog.Application.Dto.Destination.Park;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presenatation.Controllers
{
    [Route("api/destinations/parks")]
    [ApiController]

    public class ParkController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ParkController(IMediator mediator)
        {
            _mediator = mediator;
        }

        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetParkInfoQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreatePark([FromBody] ParkPostDto park)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateParkCommand
            {
                Name = park.Name,
                CreatorId = park.CreatorId,
                RegionId = park.RegionId,
                Description = park.Description,
                ImageUrl = park.ImageUrl,
                HasPlayground = park.HasPlayground,
                IsDogFriendly = park.IsDogFriendly
            });

            return Ok(result);
        }

        [HttpPut]
        [Route("{id}/update-has-playground")]
        public async Task<IActionResult> UpdatePlaygroundField(int id, [FromBody] ParkHasPlaygroundPutDto updatePlayground)
        {
            var result = await _mediator.Send(new UpdateHasPlaygroundCommand
            {
                DestinationId = id,
                HasPlayground = updatePlayground.HasPlayground,
                UserId = updatePlayground.UserId
            });

            if (result is null)
                return BadRequest();

            if(result == false)
                return Unauthorized();

            return Ok("Modification sucessfull!");
        }
    }
}
