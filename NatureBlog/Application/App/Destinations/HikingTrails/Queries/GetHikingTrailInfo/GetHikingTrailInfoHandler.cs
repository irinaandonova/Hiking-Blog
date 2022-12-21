using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.HikingTrails.Queries.GetHikingTrailInfo
{
    public class GetHikingTrailInfoHandler : IRequestHandler<GetHikingTrailInfoQuery, HikingTrailGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetHikingTrailInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<HikingTrailGetDto> Handle(GetHikingTrailInfoQuery query, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = _unitOfWork.DestinationRepository.GetHikingTrailInfo(query.Id);
                if (hikingTrail is null)
                    throw new DestinationNotFoundException("No destination with such id");

                var result = _mapper.Map<HikingTrailGetDto>(hikingTrail);
                return Task.FromResult(result);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetHikingTrailInfo Method:" + ex.Message);
                return null;
            }
        }

        
    }
}
