using NatureBlog.Domain.Models;
using NatureBlog.Domain.Models.Destinations;

namespace NatureBlog.Domain.Models
{
    public abstract class Destination
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public User Creator { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Region Region { get; set; }

        public int? RatingScore { get; set; } = null;

        public ICollection<Comment> Comments { get; set; } = null;

        public ICollection<Rating> Ratings { get; set; } 

        public ICollection<User> Visitors { get; set; } 
    }
}
