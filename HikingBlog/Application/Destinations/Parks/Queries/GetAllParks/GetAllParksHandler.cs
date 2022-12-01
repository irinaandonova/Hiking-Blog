using MediatR;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Destinations.Parks.Queries.GetAllPark;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace Application.Destinations.Parks.Queries.GetAllPark
{
    public class GetAllParksHandler : IRequestHandler<GetAllParksCommand, List<Park>>
    {
        private readonly IDestinationRepository _repository;

        public GetAllParksHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<List<Park>> Handle(GetAllParksCommand command, CancellationToken cancellationToken)
        {
            try
            {
                List<Park> allParks = _repository.GetAllParks();

                if (allParks.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                return Task.FromResult(allParks);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetAllParks Method:" + ex.Message);
                return null;
            }
        }
    }
}
