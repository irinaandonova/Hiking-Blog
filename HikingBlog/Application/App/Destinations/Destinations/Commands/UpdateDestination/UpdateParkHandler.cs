using NatureBlog.Application.Repositories;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using MediatR;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.UpdateDestination
{
    /*
    public class UpdateDestinationHandler : IRequestHandler<UpdateDestinationCommand, bool>
    {
        public readonly IDestinationRepository _repository;

        public UpdateDestinationHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<bool> Handle(UpdateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _repository.GetDestination(command.DestinationId);

                if (destination is null)
                    throw new DestinationNotFoundException("No destination with given id");
                if (destination.Creator == command.UserId)
                    _repository.Update(command.DestinationId, command.Name, command.Description, command.ImageUrl, command.Region);
                else
                    throw new DestinationNotFoundException("No destination with given id!");

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Delete Method:" + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
    */
}
