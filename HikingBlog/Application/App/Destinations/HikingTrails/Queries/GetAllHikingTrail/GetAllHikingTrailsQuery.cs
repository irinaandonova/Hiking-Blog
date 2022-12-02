using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    public class GetAllHikingTrailsQuery : IRequest<List<HikingTrail>>
    {
    }
}
