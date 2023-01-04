using Application.App.Users.Commands.CreateUser;
using Application.Dto.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Users;
using NatureBlog.Application.App.Users.Commands.DeleteUser;
using NatureBlog.Application.Dto.User;

namespace Presenatation.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
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
                return StatusCode(500);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _mediator.Send(new DeleteUserCommand { Id = id });

            if (result is null)
                return NotFound();

            if (result == false)
                return StatusCode(500);

            return Ok("User is successfully deleted!");
        }
    }
}
