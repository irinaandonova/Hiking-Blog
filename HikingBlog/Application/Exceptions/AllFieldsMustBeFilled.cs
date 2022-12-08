using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Exceptions
{
    public class AllFieldsMustBeFilled : Exception
    {
        public AllFieldsMustBeFilled()
        {
        }

        public AllFieldsMustBeFilled(string message)
                : base(message)
        {
        }

        public AllFieldsMustBeFilled(string message, Exception inner)
        : base(message, inner)
        {
        }
    }
}
