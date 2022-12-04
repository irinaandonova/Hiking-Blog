using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        public DestinationRepository()
        {
            AllDestinations = new Dictionary<Guid, Destination> { };
        }

        public Dictionary<Guid, Destination> AllDestinations { get; private set; }

        public bool Add(Destination destination)
        {
            AllDestinations.Add(destination.Id, destination);
            return true;
        }

        public bool Delete(Guid Id)
        {
            AllDestinations.Remove(Id);
            return true;
        }

        public bool Update(Guid Id, Destination destination)
        {
            AllDestinations[Id] = destination;
            return true;
        }

        public List<Destination> GetMostVisited()
        {
            List<Destination> result = (from destination in AllDestinations orderby destination.Value.Visitors.Count ascending select destination.Value).Take(10).ToList();

            return result;
        }

        public Destination GetDestination(Guid id)
        {
            if (AllDestinations.ContainsKey(id))
            {
                Destination destination = AllDestinations[id];

                return destination;
            }
            else
                return null;
        }

        public List<Seaside> GetAllSeasides()
        {
            List<Seaside> destinations = AllDestinations.Where(x => x.Value is Seaside).Select(s => s.Value as Seaside).ToList();

            return destinations;
        }

        public List<HikingTrail> GetAllHikingTrails()
        {
            try
            {
                List<HikingTrail> destinations = AllDestinations.Where(x => x.Value is HikingTrail).Select(s => s.Value as HikingTrail).ToList();
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
            List<Park> destinations = AllDestinations.Where(x => x.Value is Park).Select(s => s.Value as Park).ToList();

            return destinations;
        }

        public List<HikingTrail> FilterHikingTrails(int difficulty)
        {
            List<HikingTrail> hikingTrails = GetAllHikingTrails().Where(d => d.Difficulty == difficulty).ToList();

            return hikingTrails;
        }

        public List<Seaside> FilterSeaside(bool isGuarded, bool offercsUmbrella)
        {
            List<Seaside> seasides = GetAllSeasides();
            seasides = seasides.Where(x => x.IsGuarded == isGuarded && x.OffersUmbrella == offercsUmbrella).ToList();

            return seasides;
        }

        public List<Park> FilterParks(bool hasPlayground, bool isDogFriendly)
        {
            List<Park> parks = GetAllParks();
            parks = parks.Where(x => x.HasPlayground == hasPlayground && x.IsDogFriendly == isDogFriendly).ToList();

            return parks;
        }

        public List<Destination> FilterByRegion(string region)
        {
            List<Destination> destinations = AllDestinations.Where(d => d.Value.Region == region).Select(d => d.Value).ToList();

            return destinations;
        }

        public List<Destination> SearchByKeyword(string searchWord)
        {
            List<Destination> destinations = AllDestinations.Where(d => d.Value.Name.Contains(searchWord)).Select(d => d.Value).ToList();

            return destinations;
        }

        public List<Destination> SortDestinations(string condition)
        {
            List<Destination> result = new List<Destination> { };
            if (condition == "alphabetical")
                result = (from destination in AllDestinations orderby destination.Value.Name ascending select destination.Value).ToList();
            else if (condition == "reverse alphabetical")
                result = (from destination in AllDestinations orderby destination.Value.Name descending select destination.Value).ToList();
            else
                throw new ArgumentOutOfRangeException("Invalid condition!");

            return result;
        }

        public bool AddUmbrellaPrices(Guid id, double umbrellaPrice)
        {
            Seaside seaside = (Seaside)GetDestination(id);

            if (!seaside.OffersUmbrella)
                seaside.OffersUmbrella = true;
            seaside.UmbrellaPrice = umbrellaPrice;

            return true;
        }

        public bool RateDestination(Guid destinationId, int ratingValue, Guid userId)
        {
            Destination destination = GetDestination(destinationId);

            if (destination.Ratings.ContainsKey(userId))
                destination.Ratings[userId] = ratingValue;
            else
                destination.Ratings.Add(userId, ratingValue);

            return true;
        }

        public bool ChangeDifficulty(Guid destinationId, int difficulty, Guid userId)
        {
            HikingTrail hikingTrail = (HikingTrail)GetDestination(destinationId);
            hikingTrail.Difficulty = difficulty;

            return true;
        }
    }
}
