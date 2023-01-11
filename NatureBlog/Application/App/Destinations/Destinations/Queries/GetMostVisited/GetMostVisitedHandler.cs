using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    public class GetMostVisitedHandler : IRequestHandler<GetMostVisitedQuery, List<DestinationGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GetMostVisitedHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public Task<List<DestinationGetDto>> Handle(GetMostVisitedQuery command, CancellationToken cancellationToken) 
        {
            try 
            {
                int offset = 0;
                if (command.Page == 1)
                    offset = 0;
                else
                 offset = command.Page - 1 * 10;
                List<Destination> result = _unitOfWork.DestinationRepository.GetMostVisited(offset);

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
