using MediatR;
using NatureBlog.Domain.Models;
namespace NatureBlog.Application.App.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<bool>
    {
        public Guid DestinationId { get; set; }
        public Guid CreatorId { get; set; }
        public Guid CommentId { get; set; }
    }
}
