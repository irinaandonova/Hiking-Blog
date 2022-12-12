using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.AddUmbrellaPrices
{
    public class AddUmbrellaPricesHandler : IRequestHandler<AddUmbrellaPricesCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddUmbrellaPricesHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddUmbrellaPricesCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command.seasideId == 0 || command.umbrellaPrice <= 0)
                    throw new ArgumentOutOfRangeException("Fields are not valid");

                Seaside seaside = (Seaside)_unitOfWork.DestinationRepository.GetDestination(command.seasideId);

                if (seaside.GetType() != typeof(Seaside))
                    throw new DestinationNotFoundException("No seaside with given id");

                _unitOfWork.DestinationRepository.AddUmbrellaPrices(command.seasideId, command.umbrellaPrice);
                if (seaside.UmbrellaPrice != command.umbrellaPrice || !seaside.OffersUmbrella)
                    throw new ModificationFailedException("The umbrella prices were unsuccessfully modified!");

                await _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the AddUmbrellaPrices Method! " + ex.Message);
                return false;
            }
        }
    
    }
}