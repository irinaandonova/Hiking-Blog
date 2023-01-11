using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    public class CreateHikingTrailHandler : IRequestHandler<CreateHikingTrailCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateHikingTrailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> Handle(CreateHikingTrailCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = new HikingTrail { Name = command.name, CreatorId = command.creatorId, Description = command.description, ImageUrl = command.imageUrl, RegionId = command.regionId , Difficulty = command.difficulty, HikingDuration = command.duration };
                
                await _unitOfWork.DestinationRepository.AddHikingTrail(hikingTrail);
                await _unitOfWork.Save();
                return hikingTrail.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return null;
            }
        }
    }
}
