using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Regions.Commands.CreateRegion
{
    public class CreateRegionHandler : IRequestHandler<CreateRegionCommand, Region>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRegionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Region> Handle(CreateRegionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Region region = new Region { Name = command.Name, Cordinates = command.Cordinates };

                await _unitOfWork.RegionRepository.Add(region);
                await _unitOfWork.Save();

                return region;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
