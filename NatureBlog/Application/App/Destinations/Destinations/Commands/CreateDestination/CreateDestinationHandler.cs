using AutoMapper;
using MediatR;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Application.Dto.Destination.Park;
using NatureBlog.Application.Dto.Destination.Seaside;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;
using System.Xml.Linq;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.CreateDestination
{
    public class CreateDestinationHandler : IRequestHandler<CreateDestinationCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDestinationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int?> Handle(CreateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command.IsGuarded is not null)
                {
                    var result = _mapper.Map<SeasidePostDto>(command);
                    Seaside destination = new Seaside { Name = result.Name, CreatorId = result.CreatorId, Description = result.Description, ImageUrl = result.ImageUrl, RegionId = result.RegionId, OffersUmbrella = result.OffersUmbrella, IsGuarded = result.IsGuarded, Ratings = new List<Rating> { } };
                    await _unitOfWork.DestinationRepository.AddDestination(destination);
                    await _unitOfWork.Save();

                    return destination.Id;

                }
                else if (command.HasPlayground is not null)
                {

                    var result = _mapper.Map<ParkPostDto>(command);
                    Park destination = new Park { Name = result.Name, CreatorId = result.CreatorId, Description = result.Description, ImageUrl = result.ImageUrl, RegionId = result.RegionId, HasPlayground = result.HasPlayground, IsDogFriendly = result.IsDogFriendly, Ratings = new List<Rating> { } };
                    await _unitOfWork.DestinationRepository.AddDestination(destination);
                    await _unitOfWork.Save();

                    return destination.Id;

                }
                else if (command.Duration is not null)
                {
                    var result = _mapper.Map<HikingTrailPostDto>(command);

                    HikingTrail destination = new HikingTrail { Name = result.Name, CreatorId = result.CreatorId, Description = result.Description, ImageUrl = result.ImageUrl, RegionId = result.RegionId, Difficulty = result.Difficulty, HikingDuration = result.Duration };
                    await _unitOfWork.DestinationRepository.AddDestination(destination);
                    await _unitOfWork.Save();

                    return destination.Id;
                }
                else
                    return null;
                

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return null;
            }
        }
    }
}
