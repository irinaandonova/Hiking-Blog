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

        public void GetFirstTen()
        {
            var condition = from destination in AllDestinations orderby destination.Visitors.Count select destination;

            foreach (Destination destination in condition.Take(10))
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
            catch (ArgumentNullException)
            {
                Console.WriteLine("No such element");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("More than one destination with that name!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Destination? GetDestination(string name)
        {
            try
            {
                return AllDestinations.Single(x => x.Name == name);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No such element");
                return null;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("More than one destination with that name!");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public IEnumerable<Seaside> GetAllSeaside()
        {
            var destinations = AllDestinations.Where(x => x is Seaside).Select(s => s as Seaside);
            return destinations;
        }
        public IEnumerable<HikingTrail> GetAllHikingTrails()
        {
            var destinations = AllDestinations.Where(x => x is HikingTrail).Select(s => s as HikingTrail);
            return destinations;
        }
        public IEnumerable<Park> GetAllParks()
        {
            var destinations = AllDestinations.Where(x => x is Park).Select(s => s as Park);
            return destinations;
        }
        public void FilterHikingTrail(int difficulty)
        {
            try
            {
                IEnumerable<HikingTrail> hikingTrails = GetAllHikingTrails();

                foreach (HikingTrail hikingTrail in hikingTrails)
                {
                    hikingTrail.ShowInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void FilterSeaside(bool isGuarded)
        {
            try
            {
                IEnumerable<Seaside> seasides = GetAllSeaside();
                seasides = seasides.Where(x => x.IsGuarded);

                foreach (Seaside seaside in seasides)
                {
                    seaside.ShowInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void FilterPark(bool hasPlayground, bool isDogFriendly)
        {
            try
            {
                IEnumerable<Park> parks = GetAllParks();
                parks = parks.Where(x => x.HasPlayground == hasPlayground && x.IsDogFriendly == isDogFriendly);

                foreach (Park park in parks)
                {
                    park.ShowInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
