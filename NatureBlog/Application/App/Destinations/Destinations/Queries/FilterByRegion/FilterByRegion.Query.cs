using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion
{
    public class FilterByRegionQuerry: IRequest<List<DestinationGetDto>>
    {
        public int RegionId { get; set; }
    }
}
