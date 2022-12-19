using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;
using NatuteBlog.Application.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.App.Regions.GetAllRegions
{
    public class GetAllRegionsHandler : IRequestHandler<GetAllRegionsCommand, List<Region>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRegionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Region>> Handle(GetAllRegionsCommand command, CancellationToken cancellationToken)
        {

            return await _unitOfWork.RegionRepository.GetAll();
        }
    }
}
