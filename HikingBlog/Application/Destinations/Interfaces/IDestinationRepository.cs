using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Interfaces
{
    public interface IDestinationRepository
    {
        Dictionary<Guid, Destination> AllDestinations { get; }

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
    }
}
