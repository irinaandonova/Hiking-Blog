using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{
    public class RateDestinationCommand : IRequest<bool>
    {
        public int DestinationId { get; }

        public int RatingValue { get; set; }

        public int UserId { get; set; }
    }
}
