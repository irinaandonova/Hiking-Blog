using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    public class GetMostVisitedHandler : IRequestHandler<GetMostVisited, List<DestinationGetDto>>
    {
        private readonly IDestinationRepository _repository;
        public readonly IMapper _mapper;

        public GetMostVisitedHandler(IDestinationRepository destinationRepository, IMapper mapper)
        {
            _repository= destinationRepository;
            _mapper = mapper;

        }

        public Task<List<DestinationGetDto>> Handle(GetMostVisited command, CancellationToken cancellationToken) 
        {
            try 
            {
                List<Destination> result = _repository.GetMostVisited();
                if (result.Count < 1)
                    return Task.FromResult(new List<DestinationGetDto> { });

                var mapped = _mapper.Map<List<DestinationGetDto>>(result);

                return Task.FromResult(mapped);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
