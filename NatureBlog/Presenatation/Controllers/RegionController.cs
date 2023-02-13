using Application.Dto.Region;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Regions.Commands.CreateRegion;
using NatureBlog.Application.App.Regions.Commands.DeleteRegion;
using NatureBlog.Application.App.Regions.Queries.GetAllRegions;
using NatureBlog.Application.App.Regions.Queries.GetRegionById;
using NatureBlog.Application.Exceptions;

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
            try
            {
                var result = await _mediator.Send(new GetAllRegionsCommand());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(
                    statusCode: 500,
                    title: ex.GetType().ToString(),
                    detail: ex.Message
                    );
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetRegionByIdCommand { Id = id });

                return Ok(result);
            }
            catch (RegionNotFoundException ex)
            {
                return Problem(
                    statusCode: 400,
                    title: "No region with given id!",
                    detail: ex.Message
                    );
            }
            catch (Exception ex)
            {
                return Problem(
                    statusCode: 500,
                    title: ex.GetType().ToString(),
                    detail: ex.Message
                    );
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] RegionPostDto region)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _mediator.Send(new CreateRegionCommand
                {
                    Name = region.Name,
                    Cordinates = region.Cordinates
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(
                   statusCode: 500,
                   title: ex.GetType().ToString(),
                   detail: ex.Message
                   );
            }

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteRegionCommand { Id = id });

                return Ok("Region deleted successfully!");
            }
            catch (Exception ex)
            {
                return Problem(
                                  statusCode: 500,
                                  title: ex.GetType().ToString(),
                                  detail: ex.Message
                                  );
            }
        }
    }
}
