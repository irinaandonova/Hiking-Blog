using MediatR;

namespace Application.App.Destinations.Destinations.Commands.RateDestination
{
    public class RateDestinationCommand : IRequest<bool>
    {
        public readonly Guid destinationId;

        public int ratingValue;

        public readonly Guid userId;
    }
}
