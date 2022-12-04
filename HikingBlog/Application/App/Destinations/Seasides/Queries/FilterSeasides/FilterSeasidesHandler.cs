using NatureBlog.Application.Repositories;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Queries.FilterSeaside
{
    public class FilterSeasidesHandler
    {
        private readonly IDestinationRepository _repository;

        public FilterSeasidesHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<Seaside>> Handle(FilterSeasidesQuery query)
        {
            try
            {
                List<Seaside> seasidesList = _repository.FilterSeaside(query.IsGuarded, query.OffersUmbrellas);

                if (seasidesList.Count() < 0)
                    throw new DestinationNotFoundException("There are no destination in that fullfils those conditions!");

                return Task.FromResult(seasidesList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterHikingTrails Method! " + ex.Message);
                return null;
            }
        }
    }
}
