using Microsoft.EntityFrameworkCore;
using NatureBlog.Application.Destinations.HikingTrails.Commands;
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

        public async Task AddHikingTrail(HikingTrail destination)
        {
            await _dbContext.Destinations.AddAsync(destination);
        }

        public async Task AddSeaside(Seaside destination)
        {
            await _dbContext.Destinations.AddAsync(destination);
        }

        public async Task AddPark(Park destination)
        {
            await _dbContext.Destinations.AddAsync(destination);
        }

        public bool UpdateHikingTrail(string name, int destinationId, int regionId, string imageUrl, string description, int difficulty, int duration)
        {
            Update(destinationId, name, description, imageUrl, regionId);
            HikingTrail hikingTrail = (HikingTrail)GetDestination(destinationId);

            hikingTrail.Difficulty = difficulty;
            hikingTrail.HikingDuration = duration;

            return true;
        }

        public bool UpdateSeaside(string name, int destinationId, int regionId, string imageUrl, string description, bool isGuarded, bool offersUmbrella)
        {
            Update(destinationId, name, description, imageUrl, regionId);
            Seaside seaside = (Seaside)GetDestination(destinationId);

            seaside.IsGuarded = isGuarded;
            seaside.OffersUmbrella = offersUmbrella;

            return true;
        }

        public bool UpdatePark(string name, int destinationId, int regionId, string imageUrl, string description, bool hasPlayground, bool isDogFriendly)
        {
            Update(destinationId, name, description, imageUrl, regionId);
            Park park = (Park)GetDestination(destinationId);

            park.HasPlayground = hasPlayground;
            park.IsDogFriendly = isDogFriendly;

            return true;
        }
        public bool Delete(int Id)
        {
            Destination destination = GetDestination(Id);
            _dbContext.Destinations.Remove(destination);

            return true;
        }
        public Destination GetDestination(int id)
        {
            return (Destination)_dbContext.Destinations.Include(d => d.Visitors).Include(x => x.Ratings).SingleOrDefault(x => x.Id == id);
        }

        public bool Update(int destinationId, string name, string description, string imageUrl, int regionId)
        {
            Destination destination = GetDestination(destinationId);
            destination.Name = name;
            destination.Description = description;
            destination.ImageUrl = imageUrl;
            destination.RegionId = regionId;

            return true;
        }

        public List<Destination> GetTopThree()
        {
            List<Destination?> destinations = _dbContext.Destinations.Include(d => d.Ratings).ToList();
            foreach (Destination destination in destinations)
            {
                decimal ratingScore = CalcRatings(destination);
                destination.RatingScore = ratingScore;
            }

            destinations = destinations.OrderByDescending(d => d.RatingScore).Take(3).ToList();
            return destinations;
        }
        public List<Destination?> GetMostVisited(int offset)
        {
            List<Destination?> result = _dbContext.Destinations.Include(s => s.Visitors).Include(d => d.Ratings).ToList();

            result = result.OrderByDescending(x => x.Visitors.Count).Skip(offset).Take(10).ToList();
            foreach(var destination in result)
                destination.RatingScore = CalcRatings(destination);

            return result;
        }

        public List<Destination?> GetMostVisitedSeasides(int offset)
        {
            List<Destination?> result = _dbContext.Destinations.Where(s => s is Seaside).Include(d => d.Ratings).Include(s => s.Visitors).ToList();
            result = result.OrderByDescending(x => x.Visitors.Count).Skip(offset).Take(10).ToList();

            foreach (var destination in result)
                destination.RatingScore = CalcRatings(destination);

            return result;
        }

        public List<Destination?> GetMostVisitedParks(int offset)
        {
            List<Destination?> result = _dbContext.Destinations.Where(s => s is Park).Include(d => d.Ratings).Include(s => s.Visitors).ToList();

            result = result.OrderByDescending(x => x.Visitors.Count).Skip(offset).Take(10).ToList();
            foreach (var destination in result)
                destination.RatingScore = CalcRatings(destination);
            return result;
        }

        public List<Destination?> GetMostVisitedHikingTrails(int offset)
        {
            List<Destination?> result = _dbContext.Destinations.Where(s => s is HikingTrail).Include(d => d.Ratings).Include(s => s.Visitors).ToList();

            result = result.OrderByDescending(x => x.Visitors.Count).Skip(offset).Take(10).ToList();
            foreach (var destination in result)
                destination.RatingScore = CalcRatings(destination);
            return result;
        }
        public List<HikingTrail?> GetAllHikingTrails(int offset)
        {
            List<HikingTrail?> result = new List<HikingTrail?>();
            if (offset == 0)
                result = _dbContext.Destinations.Where(x => x is HikingTrail).Include(ht => ht.Ratings).Include(s => s.Visitors).Select(s => s as HikingTrail).Take(10).ToList();
            else
                result = _dbContext.Destinations.Where(x => x is HikingTrail).Include(ht => ht.Ratings).Select(s => s as HikingTrail).Skip(offset).Take(10).ToList();

            return result;
        }
        public int GetAllDestinationsCount()
        {
            int count = _dbContext.Destinations.Count();

            return count;
        }

        public int GetHikingTrailCount()
        {
            int count = _dbContext.Destinations.Where(x => x is HikingTrail).ToList().Count;

            return count;
        }

        public int GetParkCount()
        {
            int count = _dbContext.Destinations.Where(x => x is Park).ToList().Count;

            return count;
        }

        public int GetSeasideCount()
        {
            int count = _dbContext.Destinations.Where(x => x is Seaside).ToList().Count;

            return count;
        }

        public List<Seaside?> GetAllSeasides()
        {
            List<Seaside?> destinations = _dbContext.Destinations.Where(x => x is Seaside).Include(s => s.Ratings).Select(s => s as Seaside).ToList();

            return destinations;
        }

        public List<Seaside?> GetAllSeasides(int offset)
        {
            List<Seaside?> destinations = _dbContext.Destinations.Where(x => x is Seaside).Include(s => s.Ratings).Include(s => s.Visitors).Select(s => s as Seaside).Skip(offset).Take(10).ToList();

            return destinations;
        }

        public List<HikingTrail> GetAllHikingTrails()
        {
            try
            {
                List<HikingTrail> hikingTrails = _dbContext.Destinations.Where(x => x is HikingTrail).Include(s => s.Ratings).Include(s => s.Visitors).Select(s => s as HikingTrail).ToList();

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
            List<Park> parks = _dbContext.Destinations.Where(x => x is Park).Include(s => s.Ratings).Include(s => s.Visitors).Select(s => s as Park).ToList();

            return parks;
        }

        public List<Park> GetAllParks(int offset)
        {
            List<Park> parks = _dbContext.Destinations.Where(x => x is Park).Include(s => s.Ratings).Select(s => s as Park).Include(s => s.Visitors).Skip(offset).Take(10).ToList();

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

        public List<Destination> FilterByRegion(int regionId)
        {
            List<Destination> destinations = _dbContext.Destinations.Where(d => d.RegionId == regionId).ToList();

            return destinations;
        }

        public List<Destination> SearchByDestinationName(string searchWord)
        {

            List<Destination> destinations = _dbContext.Destinations.Where(d => d.Name.Contains(searchWord)).Select(d => d).ToList();

            return destinations;
        }

        public List<Destination> SortDestinations(string condition)
        {
            List<Destination> result = new List<Destination> { };
            if (condition == "alphabetical")
                result = _dbContext.Destinations.Include(d => d.Ratings).OrderBy(x => x.Name).ToList();
            else if (condition == "alphabetical-rev")
                result = _dbContext.Destinations.Include(d => d.Ratings).OrderByDescending(x => x.Name).ToList();
            else
                throw new ArgumentOutOfRangeException("Invalid condition!");

            return result;
        }

        public List<Destination?> SortParks(string condition)
        {
            List<Destination?> result = new List<Destination?> { };
            if (condition == "alphabetical")
                result = _dbContext.Destinations.Where(x => x is Park).Include(x => x.Ratings).OrderBy(x => x.Name).ToList();
            else if (condition == "alphabetical-rev")
                result = _dbContext.Destinations.Where(x => x is Park).Include(x => x.Ratings).OrderByDescending(x => x.Name).ToList();
            else
                throw new ArgumentOutOfRangeException("Invalid condition!");

            return result;
        }

        public List<Destination> SortSeasides(string condition)
        {
            List<Destination?> result = new List<Destination?> { };
            if (condition == "alphabetical")
                result = _dbContext.Destinations.Where(x => x is Seaside).Include(x => x.Ratings).OrderBy(x => x.Name).ToList();
            else if (condition == "alphabetical-rev")
                result = _dbContext.Destinations.Where(x => x is Seaside).Include(x => x.Ratings).OrderByDescending(x => x.Name).ToList();
            else
                throw new ArgumentOutOfRangeException("Invalid condition!");

            return result;
        }

        public List<Destination?> SortHikingTrails(string condition)
        {
            List<Destination?> result = new List<Destination?> { };
            if (condition == "alphabetical")
                result = _dbContext.Destinations.Where(x => x is HikingTrail).Include(x => x.Ratings).OrderBy(x => x.Name).ToList();
            else if (condition == "alphabetical-rev")
                result = _dbContext.Destinations.Where(x => x is HikingTrail).Include(x => x.Ratings).OrderByDescending(x => x.Name).ToList();
            else
                throw new ArgumentOutOfRangeException("Invalid condition!");

            return result;
        }

        public decimal CalcRatings(Destination destination)
        {
            int allRatings = 0;

            if (destination.Ratings.Count == 0)
                return 2.5M;

            foreach (var rating in destination.Ratings)
            {
                allRatings += rating.RatingValue;
            }
            decimal ratingScore = (decimal)allRatings / destination.Ratings.Count;

            return ratingScore;
        }

        public List<Destination?> GetBestRatedDestinations(int offset)
        {
            List<Destination?> destinations = _dbContext.Destinations.Include(d => d.Ratings).ToList();
            foreach(Destination destination in destinations)
            {
                decimal ratingScore = CalcRatings(destination);
                destination.RatingScore = ratingScore;
            }

            destinations = destinations.OrderByDescending(d => d.RatingScore).Skip(offset).ToList();
            return destinations;
        }

        public List<Destination?> GetBestRatedSeasides(int offset)
        {
            List<Destination?> destinations = _dbContext.Destinations.Where(x => x is Seaside).Include(d => d.Ratings).ToList();
            foreach (var destination in destinations)
            {
                decimal ratingScore = CalcRatings(destination);
                destination.RatingScore = ratingScore;
            }

            destinations = destinations.OrderByDescending(d => d.RatingScore).Skip(offset).ToList();
            return destinations;
        }

        public List<Destination?> GetBestRatedParks(int offset)
        {
            List<Destination?> destinations = _dbContext.Destinations.Where(x => x is Park).Include(d => d.Ratings).ToList();
            foreach (var destination in destinations)
            {
                decimal ratingScore = CalcRatings(destination);
                destination.RatingScore = ratingScore;
            }

            destinations = destinations.OrderByDescending(d => d.RatingScore).Skip(offset).ToList();
            return destinations;
        }

        public List<Destination?> GetBestRatedHikingTrails(int offset)
        {
            List<Destination?> destinations = _dbContext.Destinations.Where(x => x is HikingTrail).Include(d => d.Ratings).ToList();
            foreach (var destination in destinations)
            {
                decimal ratingScore = CalcRatings(destination);
                destination.RatingScore = ratingScore;
            }

            destinations = destinations.OrderByDescending(d => d.RatingScore).Skip(offset).ToList();
            return destinations;
        }

        public bool AddUmbrellaPrices(int id, double umbrellaPrice)
        {
            Seaside seaside = (Seaside)GetDestination(id);

            if (!seaside.OffersUmbrella)
                seaside.OffersUmbrella = true;
            seaside.UmbrellaPrice = umbrellaPrice;

            return true;
        }

        public async Task RateDestination(int destinationId, int ratingValue, int userId)
        {
               
            Rating? databaseRating = _dbContext.Ratings.SingleOrDefault(x => x.UserId == userId && x.DestinationId == destinationId);

            if (databaseRating is not null)
                databaseRating.RatingValue = ratingValue;
            else
            {
                Rating rating = new Rating { UserId = userId, DestinationId = destinationId, RatingValue = ratingValue };
                await _dbContext.Ratings.AddAsync(rating);

            }
        }

        public bool UpdatePlayground(int destinationId, bool hasPlayground)
        {
            Park park = (Park)GetDestination(destinationId);

            park.HasPlayground = hasPlayground;
            return true;
        }

        public bool UpdateIsDogFriendly(int destinationId, bool hasDogFriendly)
        {
            Park park = (Park)GetDestination(destinationId);

            park.IsDogFriendly = hasDogFriendly;
            return true;
        }

        public bool UpdateDuration(int destinationId, int duration)
        {
            HikingTrail hikingTrail = (HikingTrail)GetDestination(destinationId);

            hikingTrail.HikingDuration = duration;
            return true;
        }

        public HikingTrail GetHikingTrailInfo(int hikingTrailId)
        {
            return (HikingTrail)_dbContext.Destinations.SingleOrDefault(ht => ht.Id == hikingTrailId);
        }

        public Park GetParkInfo(int parkId)
        {
            return (Park)_dbContext.Destinations.SingleOrDefault(p => p.Id == parkId);
        }

        public List<Comment> GetComments(int destenitaionId)
        {
            Destination destination = GetDestination(destenitaionId);

            return destination.Comments.ToList();
        }

        public Destination GetFullInfo(int destenitaionId)
        {
            return _dbContext.Destinations.Include(x => x.Ratings).Include(x => x.Visitors).SingleOrDefault(x => x.Id == destenitaionId);
        }

        public async Task AddDestination(Destination destination)
        {
            await _dbContext.Destinations.AddAsync(destination);
        }

        public void VisitDestination(User userInfo, Destination destination) 
        {
            
            User? user = destination.Visitors.SingleOrDefault(u => u.Id == userInfo.Id);
            
            if(user is null)
                 destination.Visitors.Add(userInfo);
            else 
                destination.Visitors.Remove(user);

        }

        public List<User> GetVisitorsCount(int destinationId)
        {
            Destination destination = GetDestination(destinationId);

            return destination.Visitors.ToList();
        }
    }
}
