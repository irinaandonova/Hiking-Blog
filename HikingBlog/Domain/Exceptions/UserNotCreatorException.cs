using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Domain.Exceptions
{
    internal class UserNotCreatorException : Exception
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
