using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Domain.Models
{
    public class Reply : Comment
    {
        public Reply(User creator, string text, Destination destination, string mainCommentId) : base(creator, text, destination)
        {
            mainCommentId = MainCommentId;
        }

        public string MainCommentId { get; }
    }
}
