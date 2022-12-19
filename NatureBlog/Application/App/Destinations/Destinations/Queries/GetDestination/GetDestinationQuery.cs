using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetDestination
{
    public class GetDestinationQuery: IRequest<Destination>
    {
        public int Id { get; set; }
    }
}
