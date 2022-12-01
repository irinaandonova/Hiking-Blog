using MediatR;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.CreateDestination
{
    public class CreateSeasideHandler : IRequestHandler<CreateSeasideCommand, bool>
    {
        private readonly IDestinationRepository _repository;

        public CreateSeasideHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<bool> Handle(CreateSeasideCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Seaside seaside = new Seaside(command.Name, command.Creator, command.Description, command.ImageUrl, command.Region, command.IsGuarded, command.OffersUmbrella);
                _DestinationRepository.Add(seaside);

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
