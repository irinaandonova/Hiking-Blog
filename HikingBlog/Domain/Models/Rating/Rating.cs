namespace NatureBlog.Domain.Models
{
    public class Rating
    {
        public User User { get; set; }

        public int RatingValue { get; set; }
    }
}
