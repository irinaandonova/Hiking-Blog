using HikingBlog.Extensions;
using HikingBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikingBlog.Services
{
    public class WebAPI
    {
        public List<Destination> AllDestinations = new List<Destination> { };

        public void GetAllDestinations()
        {
            var condition = from destination in AllDestinations orderby destination.Visitors.Count select destination;

            foreach(Destination destination in condition.Take(10))
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
            try
            {
                Destination destination = AllDestinations.Single(x => x.Name == name);
                AllDestinations.Remove(destination);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Destination GetDestination(string name)
        {
            return AllDestinations.SingleOrDefault(x => x.Name == name);
        }
        /*
        public List<Seaside> GetAllSeaside()
        {
            return AllDestinations.Where(x => x.GetType() == typeof(Seaside));
        }
        */
       
    }
}
