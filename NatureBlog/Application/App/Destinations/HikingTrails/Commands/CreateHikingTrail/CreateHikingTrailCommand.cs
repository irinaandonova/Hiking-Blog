using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    public class CreateHikingTrailCommand: IRequest<int?>
    {
        public string Name { get; set; }

        public int CreatorId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        public int Difficulty { get; set; }

        public int Duration { get; set; }

    }
}
