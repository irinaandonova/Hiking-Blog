using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    internal class CreateHikingTrailCommand: IRequest<bool>
    {
        public string Name { get; set; }

        public Guid CreatorId { get; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Region { get; set; }

        public bool IsGuarded { get; set; }

        public int Difficulty { get; set; }

        public int Duration { get; set; }

        public int? RatingScore { get; set; } = null;

        public Dictionary<Guid, Comment> Comments { get; set; } = new Dictionary<Guid, Comment> { };

        public Dictionary<User, int> Ratings { get; set; } = new Dictionary<User, int> { };

        public List<User> Visitors { get; set; } = new List<User> { };
    }
}
