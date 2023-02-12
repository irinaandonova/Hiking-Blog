using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands
{
    public class UpdateSeasideHandler : IRequestHandler<UpdateHikingTrailCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        

        public UpdateSeasideHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateHikingTrailCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = (HikingTrail)_unitOfWork.DestinationRepository.GetDestination(command.DestinationId);

                if (hikingTrail.CreatorId != command.UserId)
                    throw new UserNotCreatorException("Current user is not the creator of this destination!");

                if (command.Difficulty < 1 || command.Difficulty > 3)
                    throw new OutOfRangeException("Difficulty must be between 1 and 3");

                _unitOfWork.DestinationRepository.UpdateHikingTrail(command.Name, command.DestinationId, command.RegionId, command.ImageUrl, command.Description, command.Difficulty, command.Duration);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Update Hiking Trail Method! " + ex.Message);
                throw ex;
            }
        }
    }
}
