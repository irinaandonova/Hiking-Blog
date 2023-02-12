namespace NatureBlog.Application.Exceptions
{
    public class ModificationFailedException : Exception
    {
        public ModificationFailedException()
        {
        }

        public ModificationFailedException(string message)
                : base(message)
        {
        }

        public ModificationFailedException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
