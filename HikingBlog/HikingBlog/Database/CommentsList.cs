using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Database
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
                        _instance.AllComments = new List<Destination> { };
                    }
                }
            }
            return _instance;
        }
        public void Attach(ISubscriber subscriber)
        {

        }
        public List<Destination> AllComments;
    }
}
