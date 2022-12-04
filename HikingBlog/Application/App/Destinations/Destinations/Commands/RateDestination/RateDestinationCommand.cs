using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{
    public class RateDestinationCommand : IRequest<bool>
    {
        public Guid destinationId { get; }

        public int ratingValue { get; set; }

        public Guid userId { get; }
    }
}
