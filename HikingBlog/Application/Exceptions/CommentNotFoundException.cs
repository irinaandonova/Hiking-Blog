using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Exceptions
{
    public class CommentNotFoundException : Exception
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

