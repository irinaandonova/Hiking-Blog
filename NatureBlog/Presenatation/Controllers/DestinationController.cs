using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination;
using NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Dto.Region;
using NatureBlog.Application.Dto.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NatureBlog.Presenatation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        public readonly IMediator _mediator;

        public DestinationController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetMostVisited()
        {
            var result = await _mediator.Send(new GetMostVisited());
            return Ok(result);
        }

        [HttpGet]
        [Route("region/{id}")]
        public IActionResult FilterByRegion(int id)
        {
            var result = _mediator.Send(new FilterByRegionQuerry { RegionId = id });
            return Ok(result.Result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDestination(int id, [FromBody] UserIdGetDto userId)
        {
            var result = await _mediator.Send(new DeleteDestinationCommand{ DestinationId = id, UserId = userId.UserId});

            if (result)
                return Ok("Destination sucessfully deleted!");

            return BadRequest();
        }


    }
}
