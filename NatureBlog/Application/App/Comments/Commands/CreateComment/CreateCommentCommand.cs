using MediatR;

namespace Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<bool>
    {
        public int destinationId;

        public string text;

        public int creatorId;
    }
}
