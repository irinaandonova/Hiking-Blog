using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface ICommentRepository
    {
        Task CreateComment(Comment comment);

        bool DeleteComment(int destinationId, int commentId);

        bool EditComment(Comment comment, string text);

        Comment GetComment(int commentId);

        List<Comment> GetComments(int id);
    }
}
