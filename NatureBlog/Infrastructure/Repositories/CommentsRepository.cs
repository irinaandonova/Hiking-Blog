using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Repositories
{
    public class CommentsRepository : ICommentRepository
    {
        private readonly AppDBContext _dbContext;

        public CommentsRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DestinationRepository DestinationRepository { get; set; }
        
        public async Task CreateComment(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
        }

        public bool DeleteComment(int destinationId, int commentId)
        {
            Comment comment = GetComment(commentId);
            _dbContext.Comments.Remove(comment);
            return true;
        }
        
        public bool EditComment(Comment comment, string text)
        {
            comment.Text = text;
            comment.Date = DateTime.Now;
            return true;
        }

        public Comment GetComment(int commentId)
        {
            return (Comment)_dbContext.Comments.SingleOrDefault(x => x.Id == commentId);
        }

        public List<Comment> GetComments(int id)
        {
            List<Comment> comments = _dbContext.Comments.Where(c => c.DestinationId == id).ToList();

            return comments;
        }
    }
}

