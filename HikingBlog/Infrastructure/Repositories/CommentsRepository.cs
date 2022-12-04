using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Comments.Interfaces;
using NatureBlog.Application.Destinations.Interfaces;

namespace Infrastructure.Repositories
{
    internal class CommentsRepository : ICommentRepository
    {
        private CommentsRepository()
        { }

        private static CommentsRepository _instance;

        private static readonly object _lock = new object();

        public static CommentsRepository GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CommentsRepository();
                        _instance.AllComments = new Dictionary<Guid, Comment> { };
                    }
                }
            }
            return _instance;
        }

        public Dictionary<Guid, Comment> AllComments;

        private readonly Dictionary<Guid, Destination> destinations;
        private readonly Dictionary<Guid, Comment> comments;

        public bool CreateComment(Guid destinationId, Guid creatorId, string text)
        {
            Destination destination = DestinationRepository.GetInstance().GetDestination(destinationId);

            Comment comment = new Comment(creatorId, text, destination.Id);
            destination.Comments.Add(comment.Id, comment);

            return true;
        }

        public bool DeleteComment(Guid destinationId, Guid commentId)
        {

            Destination destination = DestinationRepository.GetInstance().GetDestination(destinationId);

            destination.Comments.Remove(commentId);
            return true;
        }

    }
}

