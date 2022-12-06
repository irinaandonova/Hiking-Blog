using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty
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
                HikingTrail hikingTrail = (HikingTrail)_repository.GetDestination(command.DestinationId);

                if (hikingTrail.Creator != command.UserId)
                    throw new UserNotCreatorException("Current user didn't create this destination!");
                if (command.UserId == Guid.Empty)
                    throw new ArgumentNullException("User id field is missing!");
                if (command.DestinationId == Guid.Empty)
                    throw new ArgumentNullException("Destination id fields is empty!");
                if (command.Difficulty < 1 || command.Difficulty > 3)
                    throw new OutOfRangeException("Input should be from 1 to 3!");

                hikingTrail.Difficulty = command.Difficulty;

                if (hikingTrail.Difficulty != command.Difficulty)
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
