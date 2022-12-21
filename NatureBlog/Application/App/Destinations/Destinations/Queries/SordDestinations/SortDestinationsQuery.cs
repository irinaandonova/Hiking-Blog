using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SordDestinations
{
    public class SortDestinationsQuery : IRequest<List<DestinationGetDto>>
    {
        public string Condition;
    }
}
