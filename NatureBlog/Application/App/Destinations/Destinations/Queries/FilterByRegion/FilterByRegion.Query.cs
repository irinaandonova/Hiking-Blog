using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion
{
    public class FilterByRegionQuerry: IRequest<List<Destination>>
    {
        public string Region { get; set; }
    }
}
