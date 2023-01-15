using MediatR;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands
{
    public class UpdateHikingTrailCommand : IRequest<bool?>
    {
        public int DestinationId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        public int Difficulty { get; set; }

        public int Duration { get; set; }

        public int UserId { get; set; }
    }
}
