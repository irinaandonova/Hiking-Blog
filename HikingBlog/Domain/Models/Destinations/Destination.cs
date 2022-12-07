using NatureBlog.Domain.Models;

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

        public ICollection<Rating> Ratings { get; set; } 

        public ICollection<User> Visitors { get; set; } 
    }
}
