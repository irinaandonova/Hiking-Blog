using NatureBLog.Domain.Models.Region;

namespace NatureBlog.Domain.Models
{
    public abstract class Destination
    {
        public readonly Guid Id;

        public string Name { get; set; }

        public Guid Creator { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Region Region { get; set; }

        public int? RatingScore { get; set; } = null;

        public ICollection<Comment> Comments { get; set; } = null;

        public Dictionary<Guid, int> Ratings { get; set; } = new Dictionary<Guid, int> { };

        public List<User> Visitors { get; set; } = new List<User> { };
    }
}
