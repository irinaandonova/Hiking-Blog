using System.ComponentModel.DataAnnotations.Schema;

namespace NatureBlog.Domain.Models
{
    public abstract class Destination
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? RatingScore { get; set; }

        #region navigation
        public int? CreatorId { get; set; }

        public User Creator { get; set; }

        public int RegionId { get; set; }

        public Region Region { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<User> Visitors { get; set; }
        #endregion
    }
}
