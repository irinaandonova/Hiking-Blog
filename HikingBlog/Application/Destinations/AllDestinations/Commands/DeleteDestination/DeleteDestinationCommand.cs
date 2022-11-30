using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination
{
    internal class DeleteDestinationCommand: IRequest<bool>
    {
        public readonly Guid Id;
    }
}
