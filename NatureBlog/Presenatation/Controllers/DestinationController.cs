using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using NatureBlog.Application.App.Destinations.Destinations.Commands.VisitDestination;
using NatureBlog.Application.App.Destinations.Destinations.Queries.GetDestinationCount;
using NatureBlog.Application.App.Destinations.Destinations.Queries.GetFullInfoQuery;
using NatureBlog.Application.App.Destinations.Destinations.Queries.GetTopThree;
using NatureBlog.Application.App.Destinations.Parks.Commands.UpdatePark;
using NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination;
using NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination;
using NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword;
using NatureBlog.Application.Destinations.HikingTrails.Commands;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail;
using NatureBlog.Application.Destinations.Parks.Commands.CreatePark;
using NatureBlog.Application.Destinations.Parks.Queries.GetAllPark;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside;
using NatureBlog.Application.Destinations.Seasides.Commands.UpdateSeaside;
using NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Application.Dto.Destination.Park;
using NatureBlog.Application.Dto.Destination.Seaside;
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
        [Route("top-three")]
        public async Task<IActionResult> GetTopThree()
        {
            var result = await _mediator.Send(new GetTopThreeQuery { });

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }


        [HttpGet]
        [Route("all/{sorting}/{page}")]
        public async Task<IActionResult> GetMostVisited(string sorting, int page)
        {
            var result = await _mediator.Send(new GetAllDestinationsQuery { Page = page, Sorting = sorting });

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpGet]
        [Route("hiking-trails/{sorting}/{page}")]
        public async Task<IActionResult> GetAllHikingTrails(string sorting, int page)
        {
            var result = await _mediator.Send(new GetAllHikingTrailsQuery { Sorting = sorting, Page = page });

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpGet]
        [Route("seasides/{sorting}/{page}")]
        public async Task<IActionResult> GetAllSeaside(string sorting, int page)
        {
            var result = await _mediator.Send(new GetAllSeasidesQuery { Sorting = sorting, Page = page });

            if (result == null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("parks/{sorting}/{page}")]
        public async Task<IActionResult> GetAllParks(string sorting, int page)
        {
            var result = await _mediator.Send(new GetAllParksQuery { Sorting = sorting, Page = page });

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

            if (result < 0)
                return StatusCode(400);

            return Ok(result);
        }


        [HttpGet]
        [Route("info/{id}")]
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
        [Route("seaside")]
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
                IsGuarded = seaside.IsGuarded,

            });

            if (result is null)
                return BadRequest("Invalid input");

            return Ok(result);
        }

        [HttpPost]
        [Route("park")]
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
                IsDogFriendly = park.IsDogFriendly,

            });

            if (result is null)
                return BadRequest("Invalid input");

            return Ok(result);
        }

        [HttpPost]
        [Route("hiking-trail")]
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
                Duration = hikingTrail.Duration,
                Difficulty = hikingTrail.Difficulty,

            });

            if (result is null)
                return BadRequest("Invalid input");

            return Ok(result);
        }

        [HttpPut]
        [Route("hiking-trail/edit")]
        public async Task<IActionResult> UpdateHikingTrail(HikingTrailPutDto hikingTrail)
        {
            var result = await _mediator.Send(new UpdateHikingTrailCommand
            {
                DestinationId = hikingTrail.Id,
                Name = hikingTrail.Name,
                UserId = hikingTrail.UserId,
                RegionId = hikingTrail.RegionId,
                Description = hikingTrail.Description,
                ImageUrl = hikingTrail.ImageUrl,
                Difficulty = hikingTrail.Difficulty,
                Duration = hikingTrail.Duration
            });

            if (result is null)
                return BadRequest();

            if (result == false)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpPut]
        [Route("seaside/edit")]
        public async Task<IActionResult> UpdateSeaside(SeasidePutDto seaside)
        {
            var result = await _mediator.Send(new UpdateSeasideCommand
            {
                DestinationId = seaside.Id,
                Name = seaside.Name,
                UserId = seaside.UserId,
                RegionId = seaside.RegionId,
                Description = seaside.Description,
                ImageUrl = seaside.ImageUrl,
                IsGuarded = seaside.IsGuarded,
                OffersUmbrella = seaside.OffersUmbrella
            });

            if (result is null)
                return BadRequest(500);

            if (result == false)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpPut]
        [Route("park/edit")]
        public async Task<IActionResult> UpdatePark(ParkPutDto park)
        {
            var result = await _mediator.Send(new UpdateParkCommand
            {
                Id = park.Id,
                Name = park.Name,
                UserId = park.UserId,
                RegionId = park.RegionId,
                Description = park.Description,
                ImageUrl = park.ImageUrl,
                HasPlayground = park.
                IsDogFriendly = park.IsDogFriendly
            });

            if (result is null)
                return BadRequest(500);

            if (result == false)
                return StatusCode(500);

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

        [HttpPost]
        [Route("{id}/rate")]
        public async Task<IActionResult> RateDestination(int id, [FromBody] DestinationRatePostDto rating)
        {
            var result = await _mediator.Send(new RateDestinationCommand
            {
                DestinationId = id,
                UserId = rating.UserId,
                RatingValue = rating.ratingValue
            });

            if (result is null)
                return BadRequest("Invalid creator or destination id!");

            return Ok(result);

        }

        [HttpPost]
        [Route("{id}/visit")]
        public async Task<IActionResult> VisitDestination(int id, [FromBody] UserIdPostDto userInfo)
        {
            var result = await _mediator.Send(new VisitDestinationCommand
            {
                DestinationId = id,
                UserId = userInfo.UserId,
            });
            
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDestination(int id, [FromBody] UserIdPostDto userId)
        {
            var result = await _mediator.Send(new DeleteDestinationCommand { DestinationId = id, UserId = userId.UserId });

            if (result)
                return Ok("Destination sucessfully deleted!");

            return BadRequest("No destination with such id!");
        }
    }
}
