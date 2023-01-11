using MediatR;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;
using System.Xml.Linq;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.CreateDestination
{
    public class CreateDestinationHandler : IRequestHandler<CreateDestinationCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDestinationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> Handle(CreateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                /*
                if (command.IsGuarded is not null)
                {
                    Seaside destination = new Seaside { Name = command.Name, CreatorId = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, RegionId = command.RegionId, OffersUmbrella = command.OffersUmbrella, IsGuarded = command.IsGuarded }
                await _unitOfWork.DestinationRepository.AddDestination(destination);

                }
                else if (command.HasPlayground is not null)
                {
                    Park destination = new Park { Name = command.Name, CreatorId = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, RegionId = command.RegionId, HasPlayground = command.HasPlayground, IsDogFriendly = command.IsDogFriendly };
                    await _unitOfWork.DestinationRepository.AddDestination(destination);

                }
                else if (command.Duration is not null)
                {
                    HikingTrail destination = { Name = command.Name, CreatorId = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, RegionId = command.RegionId, Difficulty = command.Difficulty, HikingDuration = command.Duration }
                await _unitOfWork.DestinationRepository.AddDestination(destination);

                }
                
                
                await _unitOfWork.Save();
                return destination.Id;*/

                return 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return null;
            }
        }
    }
}
