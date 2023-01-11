using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetFullInfoQuery
{
    public class GetFullInfoQuery : IRequest<DestinationGetDto>
    {
        public int Id { get; set; }
    }
}
