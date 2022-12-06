using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Repositories
{
    public class CommentsRepository
    {
        public CommentsRepository(DestinationRepository destinationRepository)
        {
            AllComments = new Dictionary<Guid, Comment> { };
            DestinationRepository= destinationRepository;
        }

        public Dictionary<Guid, Comment> AllComments;

        public DestinationRepository DestinationRepository { get; set; }
        /*
        public bool CreateComment(Guid destinationId, Guid creatorId, string text)
        {
            Destination destination = DestinationRepository.GetDestination(destinationId);

            Comment comment = new Comment { Destination = Guid.NewGuid(), Text = text };
            destination.Comments.Add(comment.Id);

            return true;
        }

        public bool DeleteComment(Guid destinationId, Guid commentId)
        {
            Destination destination = DestinationRepository.GetDestination(destinationId);

            destination.Comments.Remove(commentId);
            return true;
        }
        */
    }
}

