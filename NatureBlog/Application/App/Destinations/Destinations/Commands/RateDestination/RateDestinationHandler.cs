using NatureBlog.Application.Repositories;
using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{
    
    public class RateDestinationHandler : IRequestHandler<RateDestinationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RateDestinationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command.RatingValue <= 0 || command.RatingValue > 5)
                    throw new ArgumentOutOfRangeException("Rating value should be between 1 and 2");
                if (command.UserId == 0)
                    throw new ArgumentNullException("User field is missing!");
                
                bool response = _unitOfWork.DestinationRepository.RateDestination(command.DestinationId, command.RatingValue, command.UserId);
                await _unitOfWork.Save();

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
