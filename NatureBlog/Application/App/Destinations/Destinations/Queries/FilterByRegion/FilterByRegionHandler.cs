using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using AutoMapper;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.FilterByRegion
{
    public class FilterByRegionHandler : IRequestHandler<FilterByRegionQuerry, List<DestinationGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FilterByRegionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<DestinationGetDto>> Handle(FilterByRegionQuerry querry, CancellationToken cancellationToken)
        {

            try
            {
                List<Destination> destinations = _unitOfWork.DestinationRepository.FilterByRegion(querry.RegionId);

                if (destinations.Count > 0)
                {
                    var mappedResult = _mapper.Map<List<DestinationGetDto>>(destinations);

                    return Task.FromResult(mappedResult);
                }
                else
                    return Task.FromResult(new List<DestinationGetDto>());

            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterRegion Method! " + ex.Message);
                return null;
            }
        }

    }
}
