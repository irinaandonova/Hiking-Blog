using Application.Dto.Region;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Regions.GetAllRegions;
using NatureBlog.Application.Dto.Region;
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

        // GET: api/<RegionController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRegionsCommand());
            return Ok(result);
        }

        // POST api/<RegionController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegionPostDto region)
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
    }
}
