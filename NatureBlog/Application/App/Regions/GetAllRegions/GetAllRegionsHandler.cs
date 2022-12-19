using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Region;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Regions.GetAllRegions
{
    public class GetAllRegionsHandler : IRequestHandler<GetAllRegionsCommand, ICollection<RegionGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRegionsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ICollection<RegionGetDto>> Handle(GetAllRegionsCommand command, CancellationToken cancellationToken)
        {
            ICollection<Region> result = await _unitOfWork.RegionRepository.GetAll();

            var mappedResult = _mapper.Map<ICollection<RegionGetDto>>(result);
            return mappedResult;

        }
    }
}
