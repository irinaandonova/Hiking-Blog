using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Comments.Interfaces
{
    internal interface ICommentService
    {
        void CreateComment(Guid destinationId, User creator, string text, string mainCommentId);

        void DeleteComment(Guid destinationId, User creator, Guid commentId);

        void EditComment(Guid destinationId, User creator, Guid commentId, string text);
    }
}
