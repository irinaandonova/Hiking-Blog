using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    public class GetAllDestinationsHandler : IRequestHandler<GetAllDestinationsQuery, List<DestinationGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IMapper _mapper;

        public GetAllDestinationsHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public Task<List<DestinationGetDto>>? Handle(GetAllDestinationsQuery command, CancellationToken cancellationToken) 
        {
            try 
            {
                int count = _unitOfWork.DestinationRepository.GetAllDestinationsPagesCount();
                int offset = 0;
                if (command.Page != 1)
                 offset = (command.Page -1) * 10;
                
                List<Destination> result = new List<Destination>();

                if (command.Sorting == "visitors")
                    result = _unitOfWork.DestinationRepository.GetMostVisited(offset);
                else if (command.Sorting == "rating")
                    result = _unitOfWork.DestinationRepository.GetBestRatedDestinations(offset);
                else
                    result = _unitOfWork.DestinationRepository.SortDestinations(command.Sorting);
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
