using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Users;

namespace Presenatation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IMapper _mapper;
        public readonly IMediator _mediator;

        public UserController(IMapper mapper, IMediator mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] UserPostDto user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new CreateUserCommand
            {
                Username = user.Username,
                Email = user.Email,
                HikingSkill = user.HikingSkill
            });
            if (result is null)
                return BadRequest("Creating user failed");

            var mappedResult = _mapper.Map<UserGetDto>(result);
            return Ok(mappedResult);
        }
    }
}
