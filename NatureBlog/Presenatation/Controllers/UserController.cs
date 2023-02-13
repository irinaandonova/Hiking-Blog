using Application.App.Users.Commands.CreateUser;
using Application.Dto.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Users.Commands.DeleteUser;
using NatureBlog.Application.App.Users.Queries;
using NatureBlog.Application.Exceptions;

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

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            try
            {
                var result = await _mediator.Send(new GetUserQuery { Email = email });

                return Ok(result);
            }
            catch(UserNotFoundException ex)
            {
                return Problem(
                    statusCode: 400,
                    title: "UserNotFoundException",
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
        public async Task<ActionResult> CreateUser([FromBody] UserPostDto user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _mediator.Send(new CreateUserCommand
                {
                    Username = user.Username,
                    Email = user.Email,
                    HikingSkill = user.HikingSkill
                });

                return Ok(result);
            }
            catch(AllFieldsMustBeFilledException ex)
            {
                return Problem(
                    statusCode: 400,
                    title: "AllFieldsMustBeFilledException",
                    detail: ex.Message
                    );
            }
            catch (OutOfRangeException ex)
            {
                return Problem(
                    statusCode: 400,
                    title: "OutOfRangeException",
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteUserCommand { Id = id });

                return Ok("User is successfully deleted!");
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
