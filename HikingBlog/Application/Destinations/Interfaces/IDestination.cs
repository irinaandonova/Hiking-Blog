using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Interfaces
{
    internal interface IDestination
    {
        List<Destination> GetMostVisited(int numberOfDestinations);

        Destination GetDestination(Guid destinationId);

        List<Seaside> GetSeasides();

        List<HikingTrail> GetHikingTrails();

        List<Park> GetParks();

        List<HikingTrail> FilterHikingTrails(int difficulty);

        List<Seaside> FilterSeaside(bool isGuarded);

        List<Park> FilterPArk(bool isDogFriendly, bool hasPlayground);

        List<Destination> FikterByRegeon(string regeon);

        List<Destination> SearchDestination(string searchWord);

        List<Destination> SortDestinations(string condition);

        bool AddUmbrellaPrices(Guid id, double umbrellaPrice);

        bool RateDestination(Guid destinationId, int ratingValue, User user);
        
        bool ChangeDifficulty(Guid destinationId, int difficulty);
    }
}
