using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    public class GetMostVisitedQuery: IRequest<List<DestinationGetDto>>
    {
        public int Page { get; set; } 
    }
}
