using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface ICommentRepository
    {
        bool CreateComment(int destinationId, int creatorId, string text);

        bool DeleteComment(int destinationId, int commentId);

        //bool EditCommentMethod(int destinationId, int commentId, string text);

    }
}
