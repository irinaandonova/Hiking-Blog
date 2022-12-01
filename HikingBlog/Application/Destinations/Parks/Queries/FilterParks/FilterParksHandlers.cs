using MediatR;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Queries.FilterParks
{
    public class FilterParksHandler : IRequestHandler<FilterParksCommand, List<Park>>
    {
        private readonly IDestinationRepository _repository;

        public FilterParksHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<Park>> Handle(FilterParksCommand command)
        {
            try
            {
                List<Park> parksList = _repository.FilterParks(command.HasPlayground, command.IsDogFriendly);

                if (parksList.Count() < 0)
                    throw new DestinationNotFoundException("The are no destinations in that fullfils  conditions!");

                return Task.FromResult(parksList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterParks Method" + ex.Message);
                return null;
            }
        }
    }
}
