using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Region;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Regions.GetAllRegions
{
    public class GetAllRegionsHandler : IRequestHandler<GetAllRegionsCommand, List<RegionGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRegionsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<RegionGetDto>> Handle(GetAllRegionsCommand command, CancellationToken cancellationToken)
        {
            List<Region> result = await _unitOfWork.RegionRepository.GetAll();

            var mappedResult = _mapper.Map<List<RegionGetDto>>(result);
            return mappedResult;

        }
    }
}
