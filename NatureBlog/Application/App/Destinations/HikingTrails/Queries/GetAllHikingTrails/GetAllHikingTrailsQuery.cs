using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;

namespace NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    public class GetAllHikingTrailsQuery: IRequest<List<DestinationGetDto>>
    {
        public int Page { get; set; }

        public string Sorting { get; set; }
    }
}
