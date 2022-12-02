using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Comments.Interfaces;
using NatureBlog.Application.Destinations.Interfaces;

namespace Infrastructure
{
    internal class Comments : ICommentRepository
    {
        private Comments()
        { }

        private static Comments _instance;

        private static readonly object _lock = new object();

        public static Comments GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Comments();
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
            Destination destination = Destinations.GetInstance().GetDestination(destinationId);

            Comment comment = new Comment(creatorId, text, destination.Id);
            destination.Comments.Add(comment.Id, comment);

            return true;
        }

        public bool DeleteComment(Guid destinationId, Guid commentId)
        {
           
                Destination destination = Destinations.GetInstance().GetDestination(destinationId);

                destination.Comments.Remove(commentId);
            return true;
            }
            
        }
    }

