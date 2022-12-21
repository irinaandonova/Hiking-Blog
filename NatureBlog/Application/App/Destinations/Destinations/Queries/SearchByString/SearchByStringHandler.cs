using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.Destination;
using AutoMapper;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.SearchByKeyword
{
    public class SearchByStringHandler : IRequestHandler<SearchByStringQuery, List<DestinationGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SearchByStringHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<List<DestinationGetDto>> Handle(SearchByStringQuery query, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(query.KeyString))
                    throw new ArgumentNullException("Key string can't be empty string or null!");

                List<Destination> destinations = _unitOfWork.DestinationRepository.SearchByKeyword(query.KeyString);
                
                if (destinations.Count == 0)
                    return Task.FromResult(new List<DestinationGetDto> { });
                
                List<DestinationGetDto> mappedResult = _mapper.Map<List<DestinationGetDto>>(destinations);

                return Task.FromResult(mappedResult);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Search Method! " + ex.Message);
                return null;
            }
        }
    }
}
