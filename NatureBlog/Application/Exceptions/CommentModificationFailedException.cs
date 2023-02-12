namespace NatureBlog.Application.Exceptions
{
    public class CommentModificationFailedException: Exception
    {
        public CommentModificationFailedException()
        {
        }

        public CommentModificationFailedException(string message)
                : base(message)
        {
        }

        public CommentModificationFailedException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
