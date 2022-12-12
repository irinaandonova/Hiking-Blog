using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatuteBlog.Application.Regions
{
    public class CreateRegionHandler : IRequestHandler<CreateRegionCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateRegionHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateRegionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Region region = new Region { Name = command.Name, Cordinates = command.Cordinates };

                await _unitOfWork.RegionRepository.Add(region);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }
    }
}
