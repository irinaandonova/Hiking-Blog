namespace NatureBlog.Domain.Models
{
    public abstract class Destination
    {
        public readonly Guid Id;

        public Destination(string name, User creator, string description, string imageUrl, string region)
        {
                Id = Guid.NewGuid();
                Name = name;
                Creator = creator.Id;
                Description = description;
                ImageUrl = imageUrl;
                Region = region;
        }

        public string Name { get; }

        public Guid Creator { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public string Region { get; }

        public int? RatingScore { get; set; } = null;

        public Dictionary<Guid, Comment> Comments { get; set; } = new Dictionary<Guid, Comment> { };

        public Dictionary<Guid, int> Ratings { get; set; } = new Dictionary<Guid, int> { };

        public List<User> Visitors { get; set; } = new List<User> { };
    }
}
