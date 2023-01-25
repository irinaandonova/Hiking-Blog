using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetTopThree
{
    public class GetTopThreeQuery : IRequest<List<DestinationGetDto>>
    {
    }
}
