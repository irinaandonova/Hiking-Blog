namespace NatureBlog.Application.Exceptions
{
    public class CommentCreationFailedException: Exception
    {
        public CommentCreationFailedException()
        {
        }

        public CommentCreationFailedException(string message)
                : base(message)
        {
        }

        public CommentCreationFailedException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
