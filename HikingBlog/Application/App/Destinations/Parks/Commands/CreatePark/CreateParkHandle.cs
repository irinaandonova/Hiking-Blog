using Application.Repositories;
using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Commands.CreatePark
{
    public class CreateParkHandler : IRequestHandler<CreateParkCommand, bool>
    {
        private readonly IDestinationRepository _DestinationRepository;

        public CreateParkHandler(IDestinationRepository DestinationRepository)
        {
            _DestinationRepository = DestinationRepository;
        }

        public Task<bool> Handle(CreateParkCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Park park = new Park(command.Name, command.Creator, command.Description, command.ImageUrl, command.Region, command.HasPlayground, command.IsDogFriendly);
                _DestinationRepository.Add(park);

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
