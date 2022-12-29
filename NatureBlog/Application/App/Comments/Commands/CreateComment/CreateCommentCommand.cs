using MediatR;

namespace NatureBlog.Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<int?>
    {
        public int DestinationId;

        public int CreatorId;

        public string Text;
    }
}
