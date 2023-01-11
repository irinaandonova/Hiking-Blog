using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.Park;
using AutoMapper;

namespace NatureBlog.Application.Destinations.Parks.Queries.GetAllPark
{
    public class GetAllParksHandler : IRequestHandler<GetAllParksQuery, List<ParkGetDto>>
    {
        private readonly IDestinationRepository _repository;
        private readonly IMapper _mapper;
        public GetAllParksHandler(IDestinationRepository DestinationRepository, IMapper mapper)
        {
            _repository = DestinationRepository;
            _mapper = mapper;
        }

        public Task<List<ParkGetDto>> Handle(GetAllParksQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int offset = 0;
                if (query.Page == 1)
                    offset = 0;
                else
                    offset = query.Page - 1 * 10;

                List<Park> allParks = _repository.GetAllParks(offset);

                if (allParks.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");
                var mappedResult = _mapper.Map<List<ParkGetDto>>(allParks);

                return Task.FromResult(mappedResult);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetAllParks Method:" + ex.Message);
                return null;
            }
        }
    }
}
