using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword
{
    public class SearchByDestinationNameQuery : IRequest<List<DestinationGetDto>>
    {
        public string KeyString { get; set; }
    }
}
