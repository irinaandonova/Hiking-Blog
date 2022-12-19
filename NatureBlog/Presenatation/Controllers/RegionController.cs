using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatuteBlog.Application.Regions;

namespace Presenatation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        public class RegionController : ControllerBase
        {
            public readonly IMapper _mapper;
            public readonly IMediator _mediator;

            public RegionController(IMapper mapper, IMediator mediator)
            {
                _mediator = mediator;
                _mapper = mapper;
            }

            // GET: api/<RegionController>
            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var result = await _mediator.Send(new GetAllRegionsCommand());
                var mappedResult = _mapper.Map<List<RegionGetDto>>(result);
                return Ok(mappedResult);
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

                var mappedResult = _mapper.Map<RegionGetDto>(result);
                return Ok(mappedResult);
            }
        }
}
