namespace NatureBlog.Domain.Models
{
    public class User 
    {
        public readonly Guid Id;

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Destination> VisitedDestinations { get; set; }
    }
}
