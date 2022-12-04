using Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SordDestinations
{
    public class SortDestinationsHandler : IRequestHandler<SortDestinationsQuery, List<Destination>>
    {
        private readonly IDestinationRepository _repository;
        public SortDestinationsHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<Destination>> Handle(SortDestinationsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(query.condition))
                    throw new ArgumentNullException("condition can't be empty string or null!");

                List<Destination> destinations = _repository.SortDestinations(query.condition);
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
