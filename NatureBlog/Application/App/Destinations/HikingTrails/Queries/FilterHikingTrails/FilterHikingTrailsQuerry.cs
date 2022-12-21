using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatuteBlog.Application.Destinations.HikingTrails.Queries.FilterHikingTrails
{
    public class FilterHikingTrailsQuery : IRequest<List<DestinationGetDto>>
    {
        public int Difficulty { get; set; }
    }
}
