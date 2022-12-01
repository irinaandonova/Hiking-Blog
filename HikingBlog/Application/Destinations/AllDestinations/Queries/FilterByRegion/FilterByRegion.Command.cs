using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion
{
    public class FilterByRegionCommand: IRequest<List<Destination>>
    {
        public string Region;
    }
}
