using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Domain.Exceptions
{
    internal class DestinationNotFoundException : Exception
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
