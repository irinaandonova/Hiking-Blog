using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Queries.GetAllPark
{/*
    public class GetAllParksHandler : IRequestHandler<GetAllParksQuery, List<Park>>
    {
        private readonly IDestinationRepository _repository;

        public GetAllParksHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<List<Park>> Handle(GetAllParksQuery query, CancellationToken cancellationToken)
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
    }*/
}
