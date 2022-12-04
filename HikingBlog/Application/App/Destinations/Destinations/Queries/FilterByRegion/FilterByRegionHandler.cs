using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion
{
    public class FilterByRegionHandler : IRequestHandler<FilterByRegionQuerry, List<Destination>>
    {
        private readonly IDestinationRepository _repository;
        public FilterByRegionHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<Destination>> Handle (FilterByRegionQuerry querry, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(querry.Region))
                    throw new ArgumentNullException("Region must be filled!");

                List<Destination> destinations = _repository.FilterByRegion(querry.Region);
                
                if (destinations.Count > 0)
                {
                    return Task.FromResult(destinations);
                }
                else
                    throw new DestinationNotFoundException("The are no elements in the collection");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterRegion Method! " + ex.Message);
                return null;
            }
        }
    }
}
