using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    public class GetAllDestinationsQuery: IRequest<List<DestinationGetDto?>>
    {
        public int Page { get; set; } 

        public string Sorting { get; set; }
    }
}
