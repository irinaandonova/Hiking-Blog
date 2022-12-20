using MediatR;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    public class GetAllHikingTrailsQuery: IRequest<List<HikingTrailGetDto>>
    {
    }
}
