using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination
{
    public class DeleteDestinationCommand: IRequest<bool>
    {
        public int Id { get; set; }

        public int DestonationId { get; set; }
    }
}
