using MediatR;
using NatureBlog.Domain.Models;

namespace Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    internal class GetAllHikingTrailsCommand: IRequest<List<HikingTrail>>
    {
    }
}
