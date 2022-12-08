using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Parks.Commands.UpdateHasPlaygroundField
{/*
    public class UpdateHasPlaygroundHandler : IRequestHandler<UpdateHasPlaygroundCommand, bool>
    {
        private readonly IDestinationRepository _repository;

        public UpdateHasPlaygroundHandler(IDestinationRepository destinationRepository)
        {
            _repository= destinationRepository;
        }

        public Task<bool> Handle(UpdateHasPlaygroundCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Park park  = (Park)_repository.GetDestination(command.DestinationId);

                if (park.Creator != command.UserId)
                    throw new UserNotCreatorException("Current user didn't create this destination!");
                if (command.UserId == Guid.Empty)
                    throw new ArgumentNullException("User id field is missing!");
                if (command.DestinationId == Guid.Empty)
                    throw new ArgumentNullException("Destination id fields is empty!");

                park.HasPlayground = command.HasPlayground;

                if (park.HasPlayground != command.HasPlayground)
                    throw new ModificationFailedException("Playground change failed!");

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the UpdateHasPlayground Method! " + ex.Message);
                return Task.FromResult(false);
            }
        }
    }*/
}
