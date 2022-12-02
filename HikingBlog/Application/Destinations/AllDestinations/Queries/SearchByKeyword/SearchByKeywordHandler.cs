using MediatR;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword
{
    public class SearchByKeywordHandler : IRequestHandler<SearchByKeywordQuery, List<Destination>>
    {
        private readonly IDestinationRepository _repository;
        public SearchByKeywordHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<Destination>> Handle(SearchByKeywordQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(query.keyword))
                    throw new ArgumentNullException("Keyword can't be empty string or null!");

                List<Destination> destinations = _repository.SearchByKeyword(query.keyword);
                if (destinations.Count == 0)
                    throw new DestinationNotFoundException("No elements that fullfil this condition!");

                return Task.FromResult(destinations);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Search Method! " + ex.Message);
                return null;
            }
        }
    }
}
