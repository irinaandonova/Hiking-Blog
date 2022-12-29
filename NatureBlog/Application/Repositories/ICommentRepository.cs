using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface ICommentRepository
    {
        bool CreateComment(Comment comment);

        bool DeleteComment(int destinationId, int commentId);

        bool EditComment(Comment comment, string text);

        Comment GetComment(int commentId);

    }
}
