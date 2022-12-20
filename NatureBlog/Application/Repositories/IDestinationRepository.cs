using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IDestinationRepository
    {
        Task AddHikingTrail(HikingTrail destination);

        Task AddPark(Park destination);

        Task AddSeaside(Seaside destination);

        bool Delete(int Id);

        Destination GetDestination(int destinationId);

        bool Update(int Id, string name, string description, string imageUrl, Region region);

        List<Destination> GetMostVisited();

        List<Seaside> GetAllSeasides();

        List<HikingTrail> GetAllHikingTrails();

        List<Park> GetAllParks();

        List<HikingTrail> FilterHikingTrails(int difficulty);

        List<Seaside> FilterSeaside(bool isGuarded, bool hasUmbrellas);

        List<Park> FilterParks(bool isDogFriendly, bool hasPlayground);

        List<Destination> FilterByRegion(Region region);

        List<Destination> SearchByKeyword(string searchWord);

        List<Destination> SortDestinations(string condition);

        bool RateDestination(int destinationId, int ratingValue, int userId);

        bool AddUmbrellaPrices(int destinationId, double price);

        bool ChangeDifficulty(int destinationId, int difficulty, int userId);

        bool UpdatePlayground(int destinationId, bool hasPlayground);

        HikingTrail GetHikingTrailInfo(int destinationId);

        Park GetParkInfo(int destinationId);
    }
}
