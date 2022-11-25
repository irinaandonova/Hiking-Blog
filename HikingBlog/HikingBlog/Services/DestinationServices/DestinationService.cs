using NatureBlog.Database;
using NatureBlog.Exceptions;
using NatureBlog.Models;
using NatureBlog.Services.DestinationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NatureBlog.Services.DestinationServices
{
    internal class DestinationService
    {
        private readonly Dictionary<Guid, Destination> destinations;

        public DestinationService()
        {
            this.destinations = DestinationsList.GetInstance().AllDestinations;
        }

        public bool Add(Destination destination)
        {
            try
            {
                this.destinations.Add(destination.Id, destination);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return false;
            }
        }

        public bool Delete(Guid Id)
        {
            try
            {
                this.destinations.Remove(Id);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return false;
            }
        }

        public bool Update(Guid Id, Destination destination)
        {
            try
            {
                if (!destinations.ContainsKey(Id))
                    throw new DestinationNotFoundException("No element found with the given key!");

                this.destinations[Id] = destination;
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Update Method:" + ex.Message);
                return false;
            }
        }

        public List<Destination> GetMostVisited()
        {

            try
            {
                List<Destination> result = (from destination in destinations orderby destination.Value.Visitors.Count ascending select destination.Value).Take(10).ToList();
                if (result.Count < 1)
                    throw new DestinationNotFoundException("No destinations in database!");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public Destination GetDestination(Guid id)
        {
            try
            {
                Destination destination = destinations[id];
                if (destination is null)
                    throw new DestinationNotFoundException("No destination with given id in database!");

                return destination;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetDestination Method:" + ex.Message);
                return null;
            }
        }

        public List<Seaside> GetAllSeaside()
        {
            try
            {
                List<Seaside> destinations = this.destinations.Where(x => x.Value is Seaside).Select(s => s.Value as Seaside).ToList();
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                return destinations;
            }

            catch (DestinationNotFoundException)
            {
                Console.WriteLine("There are no destinations yet");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetDestination Method:" + ex.Message);
                return null;
            }
        }

        public List<HikingTrail> GetAllHikingTrails()
        {
            try
            {
                List<HikingTrail> destinations = this.destinations.Where(x => x.Value is HikingTrail).Select(s => s.Value as HikingTrail).ToList();
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");
                return destinations;
            }


            catch (Exception ex)
            {
                Console.WriteLine("Exception in the GetAllHikingTrails Method" + ex.Message);
                return null;
            }
        }

        public List<Park> GetAllParks()
        {
            try
            {
                List<Park> destinations = this.destinations.Where(x => x.Value is Park).Select(s => s.Value as Park).ToList();
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                return destinations;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the GetAllParks Method" + ex.Message);
                return null;
            }
        }

        public List<HikingTrail> FilterHikingTrail(int difficulty)
        {
            try
            {
                List<HikingTrail> hikingTrails = GetAllHikingTrails().Where(d => d.Difficulty == difficulty).ToList();

                if (hikingTrails.Count() < 0)
                    throw new DestinationNotFoundException("There are no hiking trail elements that fullfil the condition in the collection");

                return hikingTrails;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterHikingTrails Method" + ex.Message);
                return null;
            }
        }

        public List<Seaside> FilterSeaside(bool isGuarded)
        {
            try
            {
                List<Seaside> seasides = GetAllSeaside();
                seasides = seasides.Where(x => x.IsGuarded).ToList();
                if (seasides.Count() < 0)
                    throw new DestinationNotFoundException("There are no destination in that fullfils this conditions");
                return seasides;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterHikingTrails Method" + ex.Message);
                return null;
            }
        }

        public List<Park> FilterPark(bool hasPlayground, bool isDogFriendly)
        {
            try
            {
                List<Park> parks = GetAllParks();
                parks = parks.Where(x => x.HasPlayground == hasPlayground && x.IsDogFriendly == isDogFriendly).ToList();

                if (parks.Count() < 0)
                    throw new DestinationNotFoundException("The are no destinations in that fullfils  conditions!");

                return parks;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<Destination> FilterByRegion(string region)
        {
            try
            {
                List<Destination> destinations = this.destinations.Where(d => d.Value.Region == region).Select(d => d.Value).ToList();
                if (destinations.Count > 0)
                {
                    return destinations;
                }
                else
                    throw new DestinationNotFoundException("The are no elements in the collection");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterRegion Method" + ex.Message);
                return null;
            }
        }

        public List<Destination> SearchDestination(string searchWord)
        {
            try
            {
                List<Destination> destinations = this.destinations.Where(d => d.Value.Name.Contains(searchWord)).Select(d => d.Value).ToList();
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("No elements that fullfil this condition!");

                return destinations;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterRegion Method" + ex.Message);
                return null;
            }
        }

        public List<Destination> SortDestinations(string condition)
        {
            try
            {
                List<Destination> result = new List<Destination> { };
                if (condition == "alphabetical")
                    result = (from destination in destinations orderby destination.Value.Name ascending select destination.Value).ToList();
                else if (condition == "reverse alphabetical")
                    result = (from destination in destinations orderby destination.Value.Name descending select destination.Value).ToList();
                else if (condition == "accending difficulty")
                    result = (from destination in destinations orderby destination.Value.Difficulty descending select destination.Value).ToList();
                else if (condition == "descending difficulty")
                    result = (from destination in destinations orderby destination.Value.Difficulty ascending select destination.Value).ToList();
                else
                    throw new ArgumentOutOfRangeException("Invalid condition!");

                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("No destinations in the collection!");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the SortDestination Method" + ex.Message);
                return null;
            }
        }

        public void AddUmbrellaPrices(Guid id, double umbrellaPrice)
        {
            try
            {
                Seaside seaside = (Seaside)GetDestination(id);
                if (!seaside.OffersUmbrella)
                    seaside.OffersUmbrella = true;
                seaside.UmbrellaPrice = umbrellaPrice;
                if (seaside is null)
                {
                    throw new DestinationNotFoundException("No destination with the given id found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the AddUmbrellaPrices Method" + ex.Message);
            }
        }

        public void RateDestination(Guid destinationId, int ratingValue, User user)
        {
            try
            {
                if (ratingValue <= 0 || ratingValue > 5)
                    throw new ArgumentOutOfRangeException("Rating value should be between 1 and 2");
                if (user == null)
                    throw new ArgumentNullException("User field is missing!");

                Destination destination = GetDestination(destinationId);
                if (destination.Ratings.ContainsKey(user))
                    destination.Ratings[user] = ratingValue;
                else
                    destination.Ratings.Add(user, ratingValue);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the RateDestination Method" + ex.Message);
            }
        }

        public void ChangeDifficulty(Guid destinationId, int difficulty)
        {
            try
            {
                Destination hikingTrail = GetDestination(destinationId);
                if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                    hikingTrail.Difficulty = difficulty;
                else
                    throw new OutOfRangeException("Input should be from 1 to 3!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
