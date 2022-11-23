using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Models
{
    internal class Reply : Comment
    {
        public Reply(User creator, string text, string mainCommentId): base(creator, text)
        {
            mainCommentId = MainCommentId;
        }

        public string MainCommentId { get; }
    }
}
