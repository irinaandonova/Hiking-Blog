using Microsoft.EntityFrameworkCore;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Repositories
{
    public class CommentsRepository
    {
        private readonly AppDBContext _dbContext;

        public CommentsRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DestinationRepository DestinationRepository { get; set; }
        
        public bool CreateComment(int destinationId, int creatorId, string text)
        {
            Destination destination = DestinationRepository.GetDestination(destinationId);

            Comment comment = new Comment { Destination = destination, Text = text };
            destination.Comments.Add(comment);
            _dbContext.SaveChanges();

            return true;
        }

        public bool DeleteComment(int destinationId, int commentId)
        {
            Destination destination = DestinationRepository.GetDestination(destinationId);
            Comment comment = GetComment(commentId);
            destination.Comments.Remove(comment);
            _dbContext.SaveChanges();

            return true;
        }
        
        public Comment GetComment(int commentId)
        {
            return (Comment)_dbContext.Comments.Select(x => x.Id == commentId);
        }
    }
}

