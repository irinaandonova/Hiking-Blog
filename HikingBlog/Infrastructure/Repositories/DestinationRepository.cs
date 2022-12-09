using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly AppDBContext _dbContext;
        public DestinationRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(HikingTrail destination)
        {
            await _dbContext.Destinations.AddAsync(destination);
            _dbContext.SaveChanges();
        }
        
        public bool Delete(int Id)
        {
            Destination destination = GetDestination(Id);
            _dbContext.Destinations.Remove(destination);
            _dbContext.SaveChanges();
            return true;
        }
        public Destination GetDestination(int id)
        {
            return (Destination)_dbContext.Destinations.Select(x => x.Id == id);
           
        }
        
        public bool Update(int destinationId, string name, string description, string imageUrl, Region region)
        {
            Destination destination = GetDestination(destinationId);
            destination.Name = name;
            destination.Description = description;
            destination.ImageUrl = imageUrl;
            destination.Region = region;

            _dbContext.SaveChanges();
            return true;
        }
        
        public List<Destination> GetMostVisited()
        {
            List<Destination> result = _dbContext.Destinations.OrderBy(x => x.Visitors.Count).Take(10).ToList(); 

            return result;
        }

        

        public List<Seaside> GetAllSeasides()
        {
            List<Seaside> destinations = _dbContext.Destinations.Where(x => x is Seaside).Select(s => s as Seaside).ToList();

            return destinations;
        }

        public List<HikingTrail> GetAllHikingTrails()
        {
            try
            {
                List<HikingTrail> hikingTrails = _dbContext.Destinations.Where(x => x is HikingTrail).Select(s => s as HikingTrail).ToList();

                return hikingTrails;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the GetAllHikingTrails Method" + ex.Message);
                return null;
            }
        }

        public List<Park> GetAllParks()
        {
            List<Park> parks = _dbContext.Destinations.Where(x => x is Park).Select(s => s as Park).ToList();

            return parks;
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

        public List<Destination> FilterByRegion(Region region)
        {
            List<Destination> destinations = _dbContext.Destinations.Where(d => d.Region.Id == region.Id).Select(d => d).ToList();

            return destinations;
        }

        public List<Destination> SearchByKeyword(string searchWord)
        {
            List<Destination> destinations = _dbContext.Destinations.Where(d => d.Name.Contains(searchWord)).Select(d => d).ToList();

            return destinations;
        }

        public List<Destination> SortDestinations(string condition)
        {
            List<Destination> result = new List<Destination> { };
            if (condition == "alphabetical")
                result = _dbContext.Destinations.OrderBy(x => x.Name).ToList();
            else if (condition == "reverse alphabetical")
                result = _dbContext.Destinations.OrderByDescending(x => x.Name).ToList();   
            else
                throw new ArgumentOutOfRangeException("Invalid condition!");

            return result;
        }

        public bool AddUmbrellaPrices(int id, double umbrellaPrice)
        {
            Seaside seaside = (Seaside)GetDestination(id);

            if (!seaside.OffersUmbrella)
                seaside.OffersUmbrella = true;
            seaside.UmbrellaPrice = umbrellaPrice;

            return true;
        }

        public bool RateDestination(int destinationId, int ratingValue, int userId)
        {

            Destination destination = GetDestination(destinationId);
            Rating rating = (Rating)destination.Ratings.Select(x => x.User.Id == userId);
            if (rating is not null)
                rating.RatingValue = ratingValue;
            else
                destination.Ratings.Add(rating);

            return true;
        }

        public bool ChangeDifficulty(int destinationId, int difficulty, int userId)
        {
            HikingTrail hikingTrail = (HikingTrail)GetDestination(destinationId);
            hikingTrail.Difficulty = difficulty;

            return true;
        }
    }
}
