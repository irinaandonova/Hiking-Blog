using Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesHandler : IRequestHandler<GetAllSeasidesQuery, List<Seaside>>
    {
        private readonly IDestinationRepository _repository;

        public GetAllSeasidesHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<List<Seaside>> Handle(GetAllSeasidesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                List<Seaside> allSeasides = _repository.GetAllSeasides();

                if (allSeasides.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                return Task.FromResult(allSeasides);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetAllSeasides Method:" + ex.Message);
                return null;
            }
        }
    }
}
