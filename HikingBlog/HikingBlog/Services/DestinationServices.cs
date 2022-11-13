using HikingBlog.Extensions;
using HikingBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikingBlog.Services
{
    internal class WebAPI
    {
        public List<Destination> AllDestinations = new List<Destination> { };

        public void GetAllDestinations()
        {
            foreach(Destination destination in AllDestinations)
            {
                destination.ShowInfo();
            }
        }
        public void AddDestination(Destination destination)
        {
            AllDestinations.Add(destination);
        }
        public void RemoveDestination(string name)
        {
            Destination destination = AllDestinations.Single(x => x.Name == name);
            AllDestinations.Remove(destination);
        }
        public Destination GetDestination(string name)
        {
            return AllDestinations.SingleOrDefault(x => x.Name == name);
        }
    }
}
