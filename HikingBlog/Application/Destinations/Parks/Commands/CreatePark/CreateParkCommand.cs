using MediatR;
using NatureBlog.Domain.Models;

namespace Application.Destinations.Parks.Commands.CreatePark
{
    public class CreateParkCommand : IRequest<bool>
    {
        public string Name { get; }

        public User Creator { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public string Region { get; }

        public int? RatingScore { get; set; } = null;

        public Dictionary<Guid, Comment> Comments { get; set; } = new Dictionary<Guid, Comment> { };

        public Dictionary<User, int> Ratings { get; set; } = new Dictionary<User, int> { };

        public List<User> Visitors { get; set; } = new List<User> { };

        public bool HasPlayground { get; set; }

        public bool IsDogFriendly { get; set; }
    }
}
