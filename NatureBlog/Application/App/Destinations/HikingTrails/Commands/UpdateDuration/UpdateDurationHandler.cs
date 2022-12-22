using AutoMapper;
using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.HikingTrails.Commands.UpdateDuration
{
    public class UpdateDurationHandler : IRequestHandler<UpdateDurationCommand, bool?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDurationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool?> Handle(UpdateDurationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination hikingTrail = _unitOfWork.DestinationRepository.GetDestination(command.DestinationId);
                if (command.UserId != hikingTrail.CreatorId)
                    return null;
                if(hikingTrail is not HikingTrail)
                    return null;

               _unitOfWork.DestinationRepository.UpdateDuration(command.DestinationId, command.HikingDuration);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in the Update Duration method: ", ex.Message);
                return false;
            }
        }
    }
}
