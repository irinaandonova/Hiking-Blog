using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.VisitDestination
{
    public class VisitDestinationCommand : IRequest<bool>
    {
        public int DestinationId { get; set; }

        public int UserId { get; set; }
    }
}
