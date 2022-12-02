using MediatR;

namespace Application.App.Destinations.Destinations.Commands.DeleteDestination
{
    internal class DeleteDestinationCommand : IRequest<bool>
    {
        public readonly Guid Id;
    }
}
