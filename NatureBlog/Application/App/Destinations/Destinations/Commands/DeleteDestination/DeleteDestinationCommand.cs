using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination
{
    public class DeleteDestinationCommand: IRequest<bool>
    {
        public int UserId { get; set; }

        public int DestinationId { get; set; }
    }
}
