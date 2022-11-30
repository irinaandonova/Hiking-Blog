using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    internal class GetMostVisitedCommand: IRequest<List<Destination>>
    {
    }
}
