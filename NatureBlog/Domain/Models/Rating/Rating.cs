using System.ComponentModel.DataAnnotations.Schema;

namespace NatureBlog.Domain.Models
{
    public class Rating
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int DestinationId { get; set; }

        public Destination Destination { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int RatingValue { get; set; }
    }
}
