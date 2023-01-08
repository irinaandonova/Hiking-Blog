using MediatR;
using NatureBlog.Application.Dto.Region;

namespace NatureBlog.Application.App.Regions.Queries.GetRegionById
{
    public class GetRegionByIdCommand : IRequest<RegionGetDto>
    {
        public int Id { get; set; }
    }
}
