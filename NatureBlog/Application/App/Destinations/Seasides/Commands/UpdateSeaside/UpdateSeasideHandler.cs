using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.UpdateSeaside
{
    public class UpdateSeasideHandler : IRequestHandler<UpdateSeasideCommand, bool?>
    {

        private readonly IUnitOfWork _unitOfWork;
        

        public UpdateSeasideHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool?> Handle(UpdateSeasideCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Seaside seaside = (Seaside)_unitOfWork.DestinationRepository.GetDestination(command.DestinationId);
                if (seaside.CreatorId != command.UserId)
                    return null;

                _unitOfWork.DestinationRepository.UpdateSeaside(command.Name, command.DestinationId, command.RegionId, command.ImageUrl, command.Description, command.IsGuarded, command.OffersUmbrella);
                await _unitOfWork.Save();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Update Seaside Method! " + ex.Message);
                return false;
            }
        }
    }
}
