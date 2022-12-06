using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.UpdateDestination
{
    public class UpdateDestinationCommand : IRequest<bool>
    {
        public Guid DestinationId { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Region { get; set; }
    }
}
