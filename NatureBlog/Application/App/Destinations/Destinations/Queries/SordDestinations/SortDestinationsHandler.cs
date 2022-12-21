using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.Destination;
using AutoMapper;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SordDestinations
{
    public class SortDestinationsHandler : IRequestHandler<SortDestinationsQuery, List<DestinationGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SortDestinationsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<DestinationGetDto>> Handle(SortDestinationsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                List<Destination> destinations = _unitOfWork.DestinationRepository.SortDestinations(query.Condition);
                if (destinations.Count() < 0)
                    return Task.FromResult(new List<DestinationGetDto> { });

                List<DestinationGetDto> mappedResult = _mapper.Map<List<DestinationGetDto>>(destinations);
                return Task.FromResult(mappedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the SortDestination Method! " + ex.Message);
                return null;
            }
        }
    }
}
