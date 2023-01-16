namespace NatureBlog.Application.Dto.Comment
{
    public class CommentGetDto
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }
    }
}
