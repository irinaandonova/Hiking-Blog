using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{
    
    public class RateDestinationHandler : IRequestHandler<RateDestinationCommand, bool?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RateDestinationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool?> Handle(RateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User user = _unitOfWork.UserRepository.GetUser(command.UserId);
                bool? response = _unitOfWork.DestinationRepository.RateDestination(command.DestinationId, command.RatingValue, command.UserId);
                await _unitOfWork.Save();
                
                if (user is null || response is null)
                    return null;

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the RateDestination Method! " + ex.Message);
                return false;
            }
        }
    }
}
