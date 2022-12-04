using Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.AddUmbrellaPrices
{
    public class AddUmbrellaPricesHandler : IRequestHandler<AddUmbrellaPricesCommand, bool>
    {
        private readonly IDestinationRepository _repository;
        public AddUmbrellaPricesHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<bool> Handle(AddUmbrellaPricesCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command.seasideId == Guid.Empty || command.umbrellaPrice <= 0)
                    throw new ArgumentOutOfRangeException("Fields are not valid");

                Seaside seaside = (Seaside)_repository.GetDestination(command.seasideId);

                if (seaside.GetType() != typeof(Seaside))
                    throw new DestinationNotFoundException("No seaside with given id");

                _repository.AddUmbrellaPrices(command.seasideId, command.umbrellaPrice);
                if (seaside.UmbrellaPrice != command.umbrellaPrice || !seaside.OffersUmbrella)
                    throw new ModificationFailedException("The umbrella prices were unsuccessfully modified!");

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the AddUmbrellaPrices Method! " + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}