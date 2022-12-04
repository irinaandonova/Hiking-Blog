using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination
{
    public class DeleteDestinationCommand: IRequest<bool>
    {
        public Guid Id { get; }
    }
}
