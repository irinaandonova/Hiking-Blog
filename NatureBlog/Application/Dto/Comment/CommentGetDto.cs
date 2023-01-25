namespace NatureBlog.Application.Dto.Comment
{
    public class CommentGetDto
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public string Username { get; set; }

        public int DestinationId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
