using MediatR;
using Microsoft.AspNetCore.Mvc;
using NatureBlog.Application.App.Comments.Commands.CreateComment;
using NatureBlog.Application.App.Comments.Commands.DeleteComment;
using NatureBlog.Application.App.Comments.Commands.EditComment;
using NatureBlog.Application.App.Destinations.Destinations.Queries.GetComments;
using NatureBlog.Application.Dto.Comment;
using NatureBlog.Application.Dto.User;


namespace WebAPI.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        public readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDestinationComments(int id)
        {
            var result = await _mediator.Send(new GetCommentsQuery { Id = id });

            if (result is null)
                return StatusCode(500);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentPostDto comment)
        {
            try
            {
                var result = await _mediator.Send(new CreateCommentCommand
                {
                    DestinationId = comment.DestinationId,
                    CreatorId = comment.CreatorId,
                    Text = comment.Text
                });

                if (result is null)
                    return StatusCode(500);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(
                    statusCode: 400,
                    title: ex.GetType().ToString().Replace("NatureBlog.Application.Exceptions.", ""),
                    detail: ex.Message
                    );
            }
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId, [FromBody] UserIdGetDto userId)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCommentCommand
                {
                    DestinationId = userId.DestinationId,
                    CommentId = commentId,
                    CreatorId = userId.UserId
                });

                if (result == false)
                    return StatusCode(500);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(
                                   statusCode: 400,
                                   title: ex.GetType().ToString().Replace("NatureBlog.Application.Exceptions.", ""),
                                   detail: ex.Message
                                   );
            }
        }

        [HttpPut]
        [Route("{id}/edit")]
        public async Task<IActionResult> EditComment(int commentId, [FromBody] CommentPutDto comment)
        {
            try
            {
                var result = await _mediator.Send(new EditCommentCommand
                {
                    Id = commentId,
                    UserId = comment.UserId,
                    Text = comment.Text
                });


                if (result == false)
                    return StatusCode(500);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return Problem(
                                   statusCode: 400,
                                   title: ex.GetType().ToString().Replace("NatureBlog.Application.Exceptions.", ""),
                                   detail: ex.Message
                                   );
            }
        }
    }
}
