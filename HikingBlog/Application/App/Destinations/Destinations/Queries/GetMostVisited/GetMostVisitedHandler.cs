using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    public class GetMostVisitedHandler : IRequestHandler<GetMostVisited, List<Destination>>
    {
        private readonly IDestinationRepository _repository;

        public GetMostVisitedHandler(IDestinationRepository destinationRepository)
        {
            _repository= destinationRepository;
        }

        public Task<List<Destination>> Handle(GetMostVisited command, CancellationToken cancellationToken) 
        {
            try 
            {
                List<Destination> result = _repository.GetMostVisited();
                if (result.Count < 1)
                    throw new DestinationNotFoundException("No destinations in database!");

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
