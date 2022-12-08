using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination
{
    /*
    public class DeleteDestinationHandler : IRequestHandler<DeleteDestinationCommand, bool>
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
    */
}
