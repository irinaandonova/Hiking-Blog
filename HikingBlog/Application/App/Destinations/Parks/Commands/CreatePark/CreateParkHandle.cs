using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Commands.CreatePark
{
    public class CreateParkHandler : IRequestHandler<CreateParkCommand, Guid>
    {
        private readonly IDestinationRepository _DestinationRepository;

        public CreateParkHandler(IDestinationRepository DestinationRepository)
        {
            _DestinationRepository = DestinationRepository;
        }

        public Task<Guid> Handle(CreateParkCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Park park = new Park { Name = command.Name, Creator = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, Region = command.Region, HasPlayground = command.HasPlayground, IsDogFriendly = command.IsDogFriendly };
                //_DestinationRepository.Add(park);

                return Task.FromResult(park.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return Task.FromResult(Guid.Empty);
            }
        }
    }
}
