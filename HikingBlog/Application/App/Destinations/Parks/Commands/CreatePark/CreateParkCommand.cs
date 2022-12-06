using MediatR;
using NatureBlog.Domain.Models;
using NatureBLog.Domain.Models.Region;

namespace NatureBlog.Application.Destinations.Parks.Commands.CreatePark
{
    public class CreateParkCommand : IRequest<Guid>
    {
        public string Name { get; set; }

        public Guid CreatorId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Region Region { get; set; }

        public int? RatingScore { get; set; } = null;

        public ICollection<Comment> Comments { get; set; } = null;

        public Dictionary<User, int> Ratings { get; set; } = new Dictionary<User, int> { };

        public ICollection<User> Visitors { get; set; } = null;

        public bool HasPlayground { get; set; }

        public bool IsDogFriendly { get; set; }
    }
}
