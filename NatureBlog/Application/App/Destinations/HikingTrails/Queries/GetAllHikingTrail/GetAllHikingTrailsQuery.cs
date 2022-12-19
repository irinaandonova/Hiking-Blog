using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    public class GetAllHikingTrailsQuery: IRequest<List<HikingTrail>>
    {
    }
}
