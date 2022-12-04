using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    internal class CreateHikingTrailHandler
    {
        private readonly IDestinationRepository _DestinationRepository;

        public CreateHikingTrailHandler(IDestinationRepository DestinationRepository)
        {
            _DestinationRepository = DestinationRepository;
        }

        public Task<bool> Handle(CreateHikingTrailCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = new HikingTrail(command.Name, command.CreatorId, command.Description, command.ImageUrl, command.Region, command.Difficulty, command.Duration);
                _DestinationRepository.Add(hikingTrail);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
