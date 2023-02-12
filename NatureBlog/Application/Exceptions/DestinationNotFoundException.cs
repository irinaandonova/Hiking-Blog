namespace NatureBlog.Application.Exceptions
{
    public class DestinationNotFoundException : Exception
    {
        public DestinationNotFoundException()
        {
        }

        public DestinationNotFoundException(string message)
                : base(message)
        {
        }

        public DestinationNotFoundException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
