using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Destinations.Destinations.Commands.CreateDestination;
using NatureBlog.Application.App.Destinations.Destinations.Queries.GetComments;
using NatureBlog.Application.App.Destinations.Destinations.Queries.GetDestinationCount;
using NatureBlog.Application.App.Destinations.Destinations.Queries.GetFullInfoQuery;
using NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination;
using NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination;
using NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword;
using NatureBlog.Application.Destinations.AllDestinations.Queries.SordDestinations;
using NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail;
using NatureBlog.Application.Destinations.Parks.Queries.GetAllPark;
using NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Dto.User;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NatureBlog.Presenatation.Controllers
{
    [Route("api/destinations")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        public readonly IMediator _mediator;

        public DestinationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all/{page}")]
        public async Task<IActionResult> GetMostVisited(int page)
        {
            var result = await _mediator.Send(new GetMostVisitedQuery { Page = page });

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }
        [HttpGet]
        [Route("hiking-trails/{page}")]
        public async Task<IActionResult> GetAllHikingTrails(int page)
        {
            var result = await _mediator.Send(new GetAllHikingTrailsQuery { Page = page });

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpGet]
        [Route("seasides/{page}")]
        public async Task<IActionResult> GetAllSeaside(int page)
        {
            var result = await _mediator.Send(new GetAllSeasidesQuery { Page = page});

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }
        [HttpGet]
        [Route("parks/{page}")]
        public async Task<IActionResult> GetAllParks(int page)
        {
            var result = await _mediator.Send(new GetAllParksQuery{ Page = page });

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        [HttpGet]
        [Route("count/{type}")]
        public async Task<IActionResult> GetCount(string type)
        {
            var result = await _mediator.Send(new GetDestinationCountQuery { Type = type });

            if (result is null)
                return StatusCode(400);

            return Ok(result);
        }


        [HttpGet]
        [Route("/info/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetFullInfoQuery { Id = id });
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> CreateHikingTrail([FromBody] DestinationGetDto destination)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateDestinationCommand
            {
                Name = destination.Name,
                CreatorId = destination.CreatorId,
                RegionId = destination.RegionId,
                Description = destination.Description,
                ImageUrl = destination.ImageUrl,
                Difficulty = destination.Difficulty,
                Duration = destination.Duration,
                HasUmbrella = destination.HasUmbrella,
                IsGuarded = destination.IsGuarded,
                HasPlayground = destination.HasPlayground,
                IsDogFriendly = destination.IsDogFriendly

            });

            if (result is null)
                return BadRequest("Invalid input");

            return Ok(result);
        }
        [HttpGet]
        [Route("region/{id}")]
        public async Task<IActionResult> FilterByRegion(int id)
        {
            var result = await _mediator.Send(new FilterByRegionQuerry { RegionId = id });

            if (result is null)
                return StatusCode(500);

            if (result.Count == 0)
                return NotFound("No destinations in this region");

            return Ok(result);
        }

        [HttpGet]
        [Route("searchq={searchString}")]
        public async Task<IActionResult> SearchByDestinationName(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return BadRequest("Search string can't be empty");

            var result = await _mediator.Send(new SearchByDestinationNameQuery { KeyString = searchString });

            if (result.Count < 0)
                return NotFound("No destination, containing this search string");

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpGet]
        [Route("sort/{condition}")]
        public async Task<IActionResult> SortDestination(string condition)
        {
            if (string.IsNullOrEmpty(condition))
                return BadRequest("Condition can't be empty!");

            var result = await _mediator.Send(new SortDestinationsQuery { Condition = condition });

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}/comments")]
        public async Task<IActionResult> GetDestinationComments(int id)
        {
            var result = await _mediator.Send(new GetCommentsQuery { Id = id });

            if (result.Count == 0)
                return NoContent();

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpPost]
        [Route("{id}/rate")]
        public async Task<IActionResult> RateDestination(int id, [FromBody] DestinationRatePostDto rating)
        {
            bool? result = await _mediator.Send(new RateDestinationCommand
            {
                DestinationId = id,
                UserId = rating.UserId,
                RatingValue = rating.ratingValue
            });

            if (result is null)
                return BadRequest("Invalid creator or destination id!");

            if (result == false)
                return StatusCode(500);

            return Ok("Destination rated successfully!");

        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDestination(int id, [FromBody] UserIdGetDto userId)
        {
            var result = await _mediator.Send(new DeleteDestinationCommand { DestinationId = id, UserId = userId.UserId });

            if (result)
                return Ok("Destination sucessfully deleted!");

            return BadRequest("No destination with such id!");
        }
    }
}
