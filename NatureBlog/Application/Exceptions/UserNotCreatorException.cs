namespace NatureBlog.Application.Exceptions
{
    public class UserNotCreatorException : Exception
    {
        public UserNotCreatorException()
        {
        }

        public UserNotCreatorException(string message)
                : base(message)
        {
        }

        public UserNotCreatorException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
