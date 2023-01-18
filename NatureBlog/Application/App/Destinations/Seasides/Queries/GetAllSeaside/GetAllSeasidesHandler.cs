using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesHandler : IRequestHandler<GetAllSeasidesQuery, List<DestinationGetDto?>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllSeasidesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<DestinationGetDto?>> Handle(GetAllSeasidesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = _unitOfWork.DestinationRepository.GetAllDestinationsCount();
                int offset = 0;
                if (query.Page == 1)
                    offset = 0;
                else
                    offset = (query.Page - 1) * 10;

                if (offset > count)
                    offset = count - 1;

                List<Destination?> result = new List<Destination?>();

                if (query.Sorting == "visitors")
                    result = _unitOfWork.DestinationRepository.GetMostVisitedSeasides(offset);
                else if (query.Sorting == "rating")
                    result = _unitOfWork.DestinationRepository.GetBestRatedSeasides(offset);
                else
                    result = _unitOfWork.DestinationRepository.SortSeasides(query.Sorting);
                if (result.Count < 1)
                    return Task.FromResult(new List<DestinationGetDto?> { });

                var mappedResult = _mapper.Map<List<DestinationGetDto>>(result);
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
