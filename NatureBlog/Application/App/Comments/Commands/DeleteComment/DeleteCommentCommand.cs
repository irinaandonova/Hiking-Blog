using MediatR;
using NatureBlog.Domain.Models;
namespace NatureBlog.Application.App.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<bool?>
    {
        public int DestinationId { get; set; }
        public int CreatorId { get; set; }
        public int CommentId { get; set; }
    }
}
