namespace NatureBlog.Domain.Models
{
    public class Rating
    {
        public int Id { get; set; }
        
        public User User { get; set; }

        public int RatingValue { get; set; }
    }
}
