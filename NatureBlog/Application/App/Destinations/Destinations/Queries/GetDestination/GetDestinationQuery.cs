using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetDestination
{
    public class GetDestinationQuery: IRequest<DestinationGetDto>
    {
        public int Id { get; set; }
    }
}
