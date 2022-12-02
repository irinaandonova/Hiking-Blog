using Application.Interfaces;
using MediatR;
using NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Destinations.Queries.SordDestinations
{
    public class SortDestinationsHandler : IRequestHandler<SortDestinationsCommand, List<Destination>>
    {
        private readonly IDestinationRepository _repository;
        public SortDestinationsHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<Destination>> Handle(SortDestinationsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(command.condition))
                    throw new ArgumentNullException("condition can't be empty string or null!");

                List<Destination> destinations = _repository.SortDestinations(command.condition);
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("No destinations in the collection!");

                return Task.FromResult(destinations);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the SortDestination Method! " + ex.Message);
                return null;
            }
        }
    }
}
