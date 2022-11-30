using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.CreateDestination
{
    public class CreateSeasideCommand : IRequest<bool>
    {
        public string Name { get; }

        public User Creator { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public string Region { get; }

        public bool IsGuarded { get; set; }

        public bool OffersUmbrella { get; set; }

        public double UmbrellaPrice { get; set; }

        public int? RatingScore { get; set; } = null;

        public Dictionary<Guid, Comment> Comments { get; set; } = new Dictionary<Guid, Comment> { };

        public Dictionary<User, int> Ratings { get; set; } = new Dictionary<User, int> { };

        public List<User> Visitors { get; set; } = new List<User> { };
    }
}
