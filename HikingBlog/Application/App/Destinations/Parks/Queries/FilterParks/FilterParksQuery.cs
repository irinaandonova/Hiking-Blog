using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Parks.Queries.FilterParks
{
    public class FilterParksQuery : IRequest<List<Park>>
    {
        public bool HasPlayground;

        public bool IsDogFriendly;
    }
}
