using Application.Repositories;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace Application.Destinations.Parks.Commands.UpdatePark
{
    public class UpdateParkHandler
    {
        public readonly IDestinationRepository _repository;

        public UpdateParkHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<bool> Handle(UpdateParkCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Park park = (Park)_repository.GetDestination(command.Id);

                if (park is null)
                    throw new DestinationNotFoundException("No destination with given id");
                if (park.Creator == command.user)
                    _repository.Update(command.Id, command.park);
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
