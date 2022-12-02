using Application.Interfaces;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class ChangeDifficultyHandler : IRequestHandler<ChangeDifficultyCommand, bool>
    {
        private readonly IDestinationRepository _repository;

        public ChangeDifficultyHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<bool> Handle(ChangeDifficultyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = (HikingTrail)_repository.GetDestination(command.destinationId);

                if (hikingTrail.Creator != command.userId)
                    throw new UserNotCreatorException("Current user didn't create this destination!");
                if (command.userId == Guid.Empty)
                    throw new ArgumentNullException("User id field is missing!");
                if (command.destinationId == Guid.Empty)
                    throw new ArgumentNullException("Destination id fields is empty!");
                if (command.difficulty < 1 || command.difficulty > 3)
                    throw new OutOfRangeException("Input should be from 1 to 3!");
                if (hikingTrail.Difficulty != command.difficulty)
                    throw new ModificationFailedException("Difficulty change failed!");

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the ChangeDifficulty Method! " + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
