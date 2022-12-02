using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Destinations.Queries.FilterByRegion
{
    public class FilterByRegionQuerry : IRequest<List<Destination>>
    {
        public string Region;
    }
}
