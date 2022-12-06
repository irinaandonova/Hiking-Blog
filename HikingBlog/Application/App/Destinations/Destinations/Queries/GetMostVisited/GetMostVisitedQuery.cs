using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    public class GetMostVisited: IRequest<List<Destination>>
    {
    }
}
