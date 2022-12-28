using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.ChangeDifficulty
{
    public class UpdateDifficultyHandler : IRequestHandler<UpdateDifficultyCommand, bool?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDifficultyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool?> Handle(UpdateDifficultyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = (HikingTrail)_unitOfWork.DestinationRepository.GetDestination(command.DestinationId);

                if (hikingTrail.CreatorId != command.UserId)
                    return null;
                if (command.Difficulty < 1 || command.Difficulty > 3)
                    return null;

                _unitOfWork.DestinationRepository.UpdateDifficulty(command.DestinationId, command.Difficulty);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the UpdateDifficulty Method! " + ex.Message);
                return false;
            }
        }
    }
}
