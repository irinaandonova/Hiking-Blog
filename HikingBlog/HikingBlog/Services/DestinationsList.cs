using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services
{
    internal class DestinationsList
    {
        private DestinationsList()
        { }

        private static DestinationsList _instance;

        // We now have a lock object that will be used to synchronize threads
        // during first access to the Singleton.
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

        public List<Destination> AllDestinations;
    }
}
