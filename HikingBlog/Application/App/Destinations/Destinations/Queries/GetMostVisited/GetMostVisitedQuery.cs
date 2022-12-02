using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Destinations.Queries.GetMostVisited
{
    public class GetMostVisitedQuery : IRequest<List<Destination>>
    {
    }
}
