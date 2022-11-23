using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Database
{
    internal class DestinationsList
    {
        private DestinationsList()
        { }

        private static DestinationsList _instance;

        private static readonly object _lock = new object();

        public static DestinationsList GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DestinationsList();
                        _instance.AllDestinations = new List<Destination> { };
                    }
                }
            }
            return _instance;
        }
        public void Attach(ISubscriber subscriber)
        {

        }
        public List<Destination> AllDestinations;
    }
}
