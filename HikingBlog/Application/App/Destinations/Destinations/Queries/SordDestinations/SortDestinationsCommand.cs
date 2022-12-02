using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Destinations.Queries.SordDestinations
{
    public class SortDestinationsCommand : IRequest<List<Destination>>
    {
        public string condition;
    }
}
