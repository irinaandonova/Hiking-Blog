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
            try
            {
                var condition = from destination in AllDestinations orderby destination.Visitors.Count select destination;
                Exceptions.CheckCount(AllDestinations);
                foreach (Destination destination in condition.Take(10))
                {
                    destination.ShowInfo();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AddDestination(Destination destination)
        {
            try
            {
                AllDestinations.Add(destination);
                if (!AllDestinations.Contains(destination))
                    throw new NotImplementedException("Element not added successfully");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Creation of destination failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
            try
            {
                var destinations = AllDestinations.Where(x => x is Seaside).Select(s => s as Seaside);
                if (destinations.Count() < 0)
                    throw new InvalidOperationException("There are no elements in the collection");
                return destinations;
            }

            catch (InvalidOperationException)
            {
                Console.WriteLine("There are no destinations yet");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public IEnumerable<HikingTrail> GetAllHikingTrails()
        {
            try
            {
                var destinations = AllDestinations.Where(x => x is HikingTrail).Select(s => s as HikingTrail);
                if (destinations.Count() < 0)
                    throw new InvalidOperationException("There are no elements in the collection");
                return destinations;
            }

            catch (InvalidOperationException)
            {
                Console.WriteLine("There are no destinations yet");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public IEnumerable<Park> GetAllParks()
        {
            try
            {
                var destinations = AllDestinations.Where(x => x is Park).Select(s => s as Park);
                if (destinations.Count() < 0)
                    throw new InvalidOperationException("There are no elements in the collection");

                return destinations;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("There are no destinations yet");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void FilterHikingTrail(int difficulty)
        {
            try
            {
                IEnumerable<HikingTrail> hikingTrails = GetAllHikingTrails();
                if (hikingTrails.Count() < 0)
                    throw new InvalidOperationException("There are no elements in the collection");

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
                if (seasides.Count() < 0)
                    throw new InvalidOperationException("There are no elements in the collection");

                foreach (Seaside seaside in seasides)
                {
                    seaside.ShowInfo();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"There are no destination in that fullfils this conditions");
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

                if (parks.Count() < 0)
                    throw new InvalidOperationException("There are no elements on the collection");

                foreach (Park park in parks)
                {
                    park.ShowInfo();
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"The are no destinations in that fullfils this conditions");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void FilterByRegion(string Region)
        {
            try
            {
                List<Destination> destinations = AllDestinations.FindAll(x => x.Region == Region);
                if (destinations.Count < 0)
                {
                    foreach (Destination destination in destinations)
                    {
                        destination.ShowInfo();
                    }
                }
                else
                    throw new InvalidOperationException("The are no elements in the collection");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"The are no destination in the {Region} region");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public IEnumerable<Destination> SearchDestination(string searchWord)
        {
            try
            {
                IEnumerable<Destination> destinations = AllDestinations.Where(d => d.Name.Contains(searchWord));
                if (destinations.Count() < 0)
                    throw new InvalidOperationException("No elements ");

                return destinations;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"The are no destinations that contain {searchWord} in their name!");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public void SortDestinations(string condition)
        {
            try
            {
                if (condition == "alphabetical")
                    AllDestinations.Sort((a, b) => a.Name.CompareTo(b.Name));
                else if (condition == "reverse alphabetical")
                    AllDestinations.Sort((b, a) => b.Name.CompareTo(a.Name));
                else if (condition == "accending difficulty")
                    AllDestinations.Sort((a, b) => b.Difficulty - a.Difficulty);
                else if (condition == "descending difficulty")
                    AllDestinations.Sort((a, b) => a.Difficulty - b.Difficulty);
                else
                    throw new ArgumentOutOfRangeException("Invalid condition");

                foreach (var destination in AllDestinations)
                    destination.ShowInfo();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                foreach (var destination in AllDestinations)
                    destination.ShowInfo();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
