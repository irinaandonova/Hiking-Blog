using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using AutoMapper;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    public class GetAllHikingTrailsHandler : IRequestHandler<GetAllHikingTrailsQuery, List<HikingTrailGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllHikingTrailsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<HikingTrailGetDto>> Handle(GetAllHikingTrailsQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int offset = 0;
                if (query.Page == 1)
                    offset = 0;
                else
                    offset = query.Page - 1 * 10;
                

                List<HikingTrail> allHikingTrails = _unitOfWork.DestinationRepository.GetAllHikingTrails(offset);

                if (allHikingTrails.Count() < 0)
                    return Task.FromResult(new List<HikingTrailGetDto> { });

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
