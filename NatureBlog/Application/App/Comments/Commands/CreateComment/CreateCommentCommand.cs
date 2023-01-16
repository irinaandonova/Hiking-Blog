using MediatR;

namespace NatureBlog.Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int?>
    {
        public int DestinationId { get; set; }

        public int CreatorId { get; set; }

        public string Text { get; set; }
    }
}
