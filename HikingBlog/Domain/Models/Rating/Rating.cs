namespace NatureBlog.Domain.Models
{
    public class Rating
    {
        public Guid UserId { get; set; }

        public int RatingValue { get; set; }
    }
}
