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
            ICollection<Destination> GetMostVisited(int numberOfDestinations);
    }
}
