using MediatR;
using NatureBlog.Application.Dto.Comment;

namespace NatureBlog.Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<CommentGetDto>
    {
        public int DestinationId { get; set; }

        public int CreatorId { get; set; }

        public string Text { get; set; }
    }
}
