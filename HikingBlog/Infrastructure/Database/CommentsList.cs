using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Database
{
    internal class CommentsList
    {
        private CommentsList()
        { }

        private static CommentsList _instance;

        private static readonly object _lock = new object();

        public static CommentsList GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new CommentsList();
                        _instance.AllComments = new Dictionary<Guid, Comment> { };
                    }
                }
            }
            return _instance;
        }
        
        public Dictionary<Guid, Comment> AllComments;
    }
}
