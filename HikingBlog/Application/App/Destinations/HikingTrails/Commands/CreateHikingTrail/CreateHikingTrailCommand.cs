using MediatR;
using NatureBlog.Domain.Models;
using NatureBLog.Domain.Models.Region;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    public class CreateHikingTrailCommand: IRequest<Guid>
    {
        public string Name { get; set; }

        public Guid CreatorId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Region Region { get; set; }

        public int Difficulty { get; set; }

        public int Duration { get; set; }

        public int? RatingScore { get; set; } = null;

        public ICollection<Comment> Comments { get; set; } = null;

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<User> Visitors { get; set; } = null;
    }
}
