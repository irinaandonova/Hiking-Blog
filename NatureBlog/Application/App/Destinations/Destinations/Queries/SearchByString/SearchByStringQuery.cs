using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword
{
    public class SearchByStringQuery : IRequest<List<DestinationGetDto>>
    {
        public string KeyString { get; set; }
    }
}
