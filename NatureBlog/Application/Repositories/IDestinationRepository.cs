using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IDestinationRepository
    {
        Task AddHikingTrail(HikingTrail destination);

        Task AddPark(Park destination);

        Task AddSeaside(Seaside destination);

        bool Delete(int destinationId);

        Destination GetDestination(int destinationId);

        bool Update(int Id, string name, string description, string imageUrl, int regionId);

        bool UpdateHikingTrail(string name, int destinationId, int regionId, string imageUrl, string description, int difficulty, int duration);

        bool UpdateSeaside(string name, int destinationId, int regionId, string imageUrl, string description, bool isGuarded, bool offersUmbrella);

        bool UpdatePark(string name, int destinationId, int regionId, string imageUrl, string description, bool hasPlayground, bool isDogFriednly);
        
        List<Destination> GetMostVisited(int offset);

        int GetAllDestinationsCount();

        int GetHikingTrailCount();

        int GetSeasideCount();

        int GetParkCount();

        List<Seaside> GetAllSeasides(int offset);

        List<HikingTrail> GetAllHikingTrails();

        List<HikingTrail> GetAllHikingTrails(int offset);

        List<Park> GetAllParks();

        List<Park> GetAllParks(int offset);


        List<HikingTrail> FilterHikingTrails(int difficulty);

        List<Seaside> FilterSeaside(bool isGuarded, bool hasUmbrellas);

        List<Park> FilterParks(bool isDogFriendly, bool hasPlayground);

        List<Destination> FilterByRegion(int regionId);

        List<Destination> SearchByDestinationName(string searchWord);

        List<Destination> SortDestinations(string condition);

        Task RateDestination(int destinationId, int ratingValue, int userId);

        bool AddUmbrellaPrices(int destinationId, double price);

        bool UpdatePlayground(int destinationId, bool hasPlayground);

        bool UpdateIsDogFriendly(int destinationId, bool isDogFriendly);

        HikingTrail GetHikingTrailInfo(int destinationId);

        Park GetParkInfo(int destinationId);

        List<Comment> GetComments(int destinationId);

        Destination GetFullInfo(int destinationId);

        Task AddDestination(Destination destination);

        

    }
}
