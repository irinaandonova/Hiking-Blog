using Microsoft.EntityFrameworkCore;
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
        
        public bool CreateComment(Comment comment)
        {
            Destination destination = DestinationRepository.GetDestination(comment.DestinationId);

            destination.Comments.Add(comment);

            return true;
        }

        public bool DeleteComment(int destinationId, int commentId)
        {
            Destination destination = DestinationRepository.GetDestination(destinationId);
            Comment comment = GetComment(commentId);
            destination.Comments.Remove(comment);

            return true;
        }
        
        public bool EditComment(Comment comment, string text)
        {
            comment.Text = text;
            return true;
        }

        public Comment GetComment(int commentId)
        {
            return (Comment)_dbContext.Comments.Select(x => x.Id == commentId);
        }
    }
}

