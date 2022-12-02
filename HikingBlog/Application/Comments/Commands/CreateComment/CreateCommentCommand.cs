using MediatR;

namespace Application.Comments.Commands.CreateComment
{
    public class CreateCommentCommand : IRequest<bool>
    {
        public Guid destinationId;

        public string text;

        public Guid creatorId;
    }
}
