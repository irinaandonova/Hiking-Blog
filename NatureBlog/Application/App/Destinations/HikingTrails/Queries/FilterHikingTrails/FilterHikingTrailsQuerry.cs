using MediatR;
using NatureBlog.Domain.Models;

namespace NatuteBlog.Application.Destinations.HikingTrails.Queries.FilterHikingTrails
{
    public class FilterHikingTrailsQuery : IRequest<List<HikingTrail>>
    {
        public int difficulty { get; set; }
    }
}
