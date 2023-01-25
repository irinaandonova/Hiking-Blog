namespace NatureBlog.Domain.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public int DestinationId { get; set; }

        public Destination Destination { get; set; }

    }
}
