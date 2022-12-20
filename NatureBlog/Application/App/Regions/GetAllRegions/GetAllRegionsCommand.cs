using MediatR;
using NatureBlog.Application.Dto.Region;

namespace NatureBlog.Application.App.Regions.GetAllRegions
{
    public class GetAllRegionsCommand : IRequest<List<RegionGetDto>>
    {
    }
}
