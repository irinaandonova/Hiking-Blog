using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    public class CreateHikingTrailCommand: IRequest<int?>
    {
        public string name { get; set; }

        public int creatorId { get; set; }

        public string description { get; set; }

        public string imageUrl { get; set; }

        public int regionId { get; set; }

        public int difficulty { get; set; }

        public int duration { get; set; }

    }
}
