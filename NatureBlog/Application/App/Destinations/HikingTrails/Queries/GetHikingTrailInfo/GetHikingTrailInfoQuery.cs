using MediatR;
using NatureBlog.Application.Dto.Destination.HikingTrail;

namespace NatureBlog.Application.App.Destinations.HikingTrails.Queries.GetHikingTrailInfo
{
    public class GetHikingTrailInfoQuery : IRequest<HikingTrailGetDto>
    {
        public int Id { get; set; }
    }
}
