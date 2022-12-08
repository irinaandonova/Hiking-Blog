using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatuteBlog.Application.Regions
{
    public class CreateRegionHandler : IRequestHandler<CreateRegionCommand, bool>
    {
        private readonly IRegionRepository _repository;

        public CreateRegionHandler(IRegionRepository RegionRepository)
        {
            _repository = RegionRepository;
        }

        public Task<bool> Handle(CreateRegionCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Region region = new Region { Id = Guid.NewGuid(), Name = command.Name, Cordinates = command.Cordinates };
                _repository.Add(region);
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Task.FromResult(false);

            }

        }
    }
}
