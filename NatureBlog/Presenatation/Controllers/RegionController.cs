using Application.Dto.Region;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Regions.DeleteRegion;
using NatureBlog.Application.App.Regions.GetAllRegions;
using NatureBlog.Application.Dto.Region;
using NatureBlog.Application.Dto.User;
using NatuteBlog.Application.Regions;

namespace Presenatation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        public readonly IMediator _mediator;

        public RegionController( IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRegionsCommand());
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
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var result = await _mediator.Send(new DeleteRegionCommand { Id = id });

            if(result)
                return Ok(result);

            return BadRequest();
        }
    }
}
