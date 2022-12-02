using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Natureblog.Application.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : IRequest<bool>
    {
        public Guid destinationId;
        public Guid creatorId;
        public Guid commentId;
    }
}
