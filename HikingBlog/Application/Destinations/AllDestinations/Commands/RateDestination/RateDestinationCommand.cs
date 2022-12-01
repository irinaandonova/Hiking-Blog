using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{
    public class RateDestinationCommand : IRequest<bool>
    {
        public readonly Guid destinationId;

        public int ratingValue;

        public readonly Guid userId;
    }
}
