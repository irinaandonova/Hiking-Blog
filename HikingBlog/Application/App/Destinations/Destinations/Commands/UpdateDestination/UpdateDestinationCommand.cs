using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.UpdateDestination
{
    public class UpdateDestinationCommand : IRequest<bool>
    {
        public int DestinationId { get; set; }

        public string Name { get; set; }

        public User User { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Region Region { get; set; }
    }
}
