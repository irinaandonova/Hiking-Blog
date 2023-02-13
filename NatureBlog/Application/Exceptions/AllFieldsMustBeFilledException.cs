using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Exceptions
{
    public class AllFieldsMustBeFilledException : Exception
    {
        public AllFieldsMustBeFilledException()
        {
        }

        public AllFieldsMustBeFilledException(string message)
                : base(message)
        {
        }

        public AllFieldsMustBeFilledException(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
