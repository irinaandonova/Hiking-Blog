using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class ChangeDifficultyHandler : IRequestHandler<ChangeDifficultyCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChangeDifficultyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ChangeDifficultyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = (HikingTrail)_unitOfWork.DestinationRepository.GetDestination(command.DestinationId);

                if (hikingTrail.CreatorId != command.UserId)
                    throw new UserNotCreatorException("Current user didn't create this destination!");
                if (command.Difficulty < 1 || command.Difficulty > 3)
                    throw new OutOfRangeException("Input should be from 1 to 3!");

                _unitOfWork.DestinationRepository.ChangeDifficulty(command.DestinationId, command.Difficulty);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the ChangeDifficulty Method! " + ex.Message);
                return false;
            }
        }
    }
}
