using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Interfaces
{
    public interface IDestinationRepository
    {
        List<Destination> GetMostVisited();

        Destination GetDestination(Guid destinationId);

        List<Seaside> GetAllSeasides();

        List<HikingTrail> GetAllHikingTrails();

        List<Park> GetAllParks();

        List<HikingTrail> FilterHikingTrails(int difficulty);

        List<Seaside> FilterSeaside(bool isGuarded);

        List<Park> FilterPark(bool isDogFriendly, bool hasPlayground);

        List<Destination> FilterByRegion(string regeon);

        List<Destination> SearchDestination(string searchWord);

        List<Destination> SortDestinations(string condition);
    }
}
