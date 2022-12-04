using MediatR;

namespace Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<bool>
    {
        public Guid destinationId;

        public string text;

        public Guid creatorId;
    }
}
