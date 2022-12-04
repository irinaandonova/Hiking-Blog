using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface ICommentRepository
    {
        bool CreateComment(Guid destinationId, Guid creatorId, string text);

        bool DeleteComment(Guid destinationId, Guid commentId);

        //bool EditCommentMethod(Guid destinationId, Guid commentId, string text);
    }
}
