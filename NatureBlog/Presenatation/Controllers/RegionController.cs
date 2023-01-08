using Application.Dto.Region;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Regions.Commands.CreateRegion;
using NatureBlog.Application.App.Regions.Commands.DeleteRegion;
using NatureBlog.Application.App.Regions.Queries.GetAllRegions;
using NatureBlog.Application.App.Regions.Queries.GetRegionById;

namespace Presenatation.Controllers
{
    [Route("api/region")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        public readonly IMediator _mediator;

        public RegionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRegionsCommand());
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetRegionByIdCommand { Id = id });

            if (result is null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] RegionPostDto region)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateRegionCommand
            {
                Name = region.Name,
                Cordinates = region.Cordinates
            });
            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var result = await _mediator.Send(new DeleteRegionCommand { Id = id });

            if (result is null)
                return BadRequest();

            if (result == false)
                return StatusCode(500);

            return Ok("Region deleted successfully!");
        }
    }
}
