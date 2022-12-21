using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatuteBlog.Application.Destinations.HikingTrails.Queries.FilterHikingTrails;
using AutoMapper;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.HikingTrails.Queries.FilterHikingTrails
{
    public class FilterHikingTrailsHandler : IRequestHandler<FilterHikingTrailsQuery, List<DestinationGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FilterHikingTrailsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<DestinationGetDto>> Handle(FilterHikingTrailsQuery querry, CancellationToken cancellationToken)
        {

            try
            {
                List<HikingTrail> hikingTrailsList = _unitOfWork.DestinationRepository.FilterHikingTrails(querry.Difficulty);

                if (hikingTrailsList.Count() < 0)
                    throw new DestinationNotFoundException("There are no hiking trail elements that fullfil the condition in the collection");

                var mappedResult = _mapper.Map<List<DestinationGetDto>>(hikingTrailsList);
                return Task.FromResult(mappedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterHikingTrails Method" + ex.Message);
                return null;
            }
        }
    }
}
