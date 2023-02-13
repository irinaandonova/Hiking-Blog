using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Region;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Regions.Queries.GetRegionById
{
    public class GetRegionByIdHandler : IRequestHandler<GetRegionByIdCommand, RegionGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetRegionByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<RegionGetDto> Handle(GetRegionByIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Region region = _unitOfWork.RegionRepository.GetRegion(command.Id);
                var mappedResult = _mapper.Map<RegionGetDto>(region);

                return Task.FromResult(mappedResult);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception in the Region Get By Id method", ex.Message);
                throw ex;
            }

        }

    }
}
