using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.Seaside;
using AutoMapper;

namespace NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesHandler : IRequestHandler<GetAllSeasidesQuery, List<SeasideGetDto>>
    {
        private readonly IDestinationRepository _repository;
        private readonly IMapper _mapper;
        public GetAllSeasidesHandler(IDestinationRepository DestinationRepository, IMapper mapper)
        {
            _repository = DestinationRepository;
            _mapper = mapper;
        }

        public Task<List<SeasideGetDto>> Handle(GetAllSeasidesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                List<Seaside> allSeasides = _repository.GetAllSeasides();

                if (allSeasides.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                var mappedResult = _mapper.Map<List<SeasideGetDto>>(allSeasides);
                return Task.FromResult(mappedResult);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetAllSeasides Method:" + ex.Message);
                return null;
            }
        }
    }
}
