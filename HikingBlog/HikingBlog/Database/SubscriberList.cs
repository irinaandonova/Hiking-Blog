using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Database
{
    internal class SubscriberList
    {
        private SubscriberList()
        { }

        private static SubscriberList _instance;

        private static readonly object _lock = new object();

        public static SubscriberList GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SubscriberList();
                        _instance.AllSubscribers = new List<User> { };
                    }
                }
            }
            return _instance;
        }

        public List<User> AllSubscribers;
    }
}
