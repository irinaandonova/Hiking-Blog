using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;

namespace Application.Destinations.Destination.Commands.DeleteDestination
{
    internal class DeleteDestinationHandler
    {
        private readonly IDestinationRepository _repository;

        public DeleteDestinationHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<bool> Handle(DeleteDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (_repository.AllDestinations.ContainsKey(command.Id))
                    _repository.Delete(command.Id);

                else
                    throw new DestinationNotFoundException("No destination with given id!");
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Delete Method:" + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
