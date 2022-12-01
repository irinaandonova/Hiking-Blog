using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Interfaces
{
    public interface IDestinationRepository
    {
        public Dictionary<Guid, Destination> AllDestinations { get; }

        bool Add(Destination destination);

        bool Delete(Guid Id);

        bool Update(Guid Id, Destination destination);

        List<Destination> GetMostVisited();

        Destination GetDestination(Guid destinationId);

        List<Seaside> GetAllSeasides();

        List<HikingTrail> GetAllHikingTrails();

        List<Park> GetAllParks();

        List<HikingTrail> FilterHikingTrails(int difficulty);

        List<Seaside> FilterSeaside(bool isGuarded, bool hasUmbrellas);

        List<Park> FilterParks(bool isDogFriendly, bool hasPlayground);

        List<Destination> FilterByRegion(string regeon);

        List<Destination> SearchByKeyword(string searchWord);

        List<Destination> SortDestinations(string condition);
    }
}
