namespace NatureBlog.Application.Exceptions
{
    internal class CommentNotFoundException : Exception
    {
        public CommentNotFoundException()
        {
        }

        public CommentNotFoundException(string message)
                : base(message)
        {
        }

        public CommentNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}

