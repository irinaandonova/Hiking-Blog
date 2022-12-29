using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.App.Comments.Commands.EditComment
{
    public class EditCommentCommand : IRequest<bool?>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }
    }
}
