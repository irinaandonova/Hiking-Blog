using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{
    public class RateDestinationCommand : IRequest<bool>
    {
        public int destinationId { get; }

        public int ratingValue { get; set; }

        public int userId { get; }
    }
}
