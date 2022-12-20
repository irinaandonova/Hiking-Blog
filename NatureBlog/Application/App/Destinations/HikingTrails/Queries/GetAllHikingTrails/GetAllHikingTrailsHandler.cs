using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using AutoMapper;

namespace NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    public class GetAllHikingTrailsHandler : IRequestHandler<GetAllHikingTrailsQuery, List<HikingTrailGetDto>>
    {
        private readonly IDestinationRepository _repository;
        private readonly IMapper _mapper;
        public GetAllHikingTrailsHandler(IDestinationRepository DestinationRepository, IMapper mapper)
        {
            _repository = DestinationRepository;
            _mapper = mapper;
        }

        public Task<List<HikingTrailGetDto>> Handle(GetAllHikingTrailsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                List<HikingTrail> allHikingTrails = _repository.GetAllHikingTrails();

                if (allHikingTrails.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                var mappedResult = _mapper.Map<List<HikingTrailGetDto>>(allHikingTrails);

                return Task.FromResult(mappedResult);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetHikingTrails Method:" + ex.Message);
                return null;
            }
        }
    }
}
