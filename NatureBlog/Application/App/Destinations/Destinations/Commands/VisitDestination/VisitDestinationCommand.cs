using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.VisitDestination
{
    public class VisitDestinationCommand : IRequest<List<User>>
    {
        public int DestinationId { get; set; }

        public int UserId { get; set; }
    }
}
