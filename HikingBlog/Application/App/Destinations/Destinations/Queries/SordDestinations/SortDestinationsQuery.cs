using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SordDestinations
{
    public class SortDestinationsQuery : IRequest<List<Destination>>
    {
        public string condition;
    }
}
