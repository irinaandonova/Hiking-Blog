using NatureBlog.Application.Repositories;
using MediatR;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.RateDestination
{
    public class RateDestinationHandler : IRequestHandler<RateDestinationCommand, bool>
    {
        private readonly IDestinationRepository _repository;

        public RateDestinationHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<bool> Handle(RateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (command.ratingValue <= 0 || command.ratingValue > 5)
                    throw new ArgumentOutOfRangeException("Rating value should be between 1 and 2");
                if (command.userId == Guid.Empty)
                    throw new ArgumentNullException("User field is missing!");

                
                
                bool response = _repository.RateDestination(command.destinationId, command.ratingValue, command.userId);
                
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the RateDestination Method! " + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
