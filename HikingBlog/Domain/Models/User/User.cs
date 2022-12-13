using System.ComponentModel.DataAnnotations.Schema;

namespace NatureBlog.Domain.Models
{
    public class User 
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Destination> VisitedDestinations { get; set; }

        public ICollection<Destination> CreatedDestinations { get; set; }

    }
}
