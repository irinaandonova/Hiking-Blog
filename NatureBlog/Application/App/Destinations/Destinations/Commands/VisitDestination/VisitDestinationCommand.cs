using MediatR;
using NatureBlog.Application.Dto.User;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.VisitDestination
{
    public class VisitDestinationCommand : IRequest<List<UserGetDto>>
    {
        public int DestinationId { get; set; }

        public int UserId { get; set; }
    }
}
