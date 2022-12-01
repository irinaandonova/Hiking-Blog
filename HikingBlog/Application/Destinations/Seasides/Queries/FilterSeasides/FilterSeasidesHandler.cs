using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace Application.Destinations.Seasides.Queries.FilterSeaside
{
    public class FilterSeasidesHandler
    {
        private readonly IDestinationRepository _repository;

        public FilterSeasidesHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<Seaside>> Handle(FilterSeasidesCommand command)
        {
            try
            {
                List<Seaside> seasidesList = _repository.FilterSeaside(command.IsGuarded, command.OffersUmbrellas);

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
