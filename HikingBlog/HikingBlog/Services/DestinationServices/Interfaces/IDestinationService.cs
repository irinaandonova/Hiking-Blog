using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services.DestinationServices.Interfaces
{
    internal interface IDestinationService
    {
        bool Add(Destination destination);

        bool Delete(Destination destination);

        bool Update(Guid destinationId, Destination updatedDestination);

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

        void AddUmbrellaPrices(Guid id, double umbrellaPrice);

        void RateDestination(Guid destinationId, int ratingValue, User user);

        void ChangeDifficulty(Guid destinationId, int difficulty);
    }
}
