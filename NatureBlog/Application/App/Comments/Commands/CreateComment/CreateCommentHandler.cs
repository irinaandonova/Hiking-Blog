using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Comment comment = new Comment { DestinationId = command.DestinationId, CreatorId = command.CreatorId, Text = command.Text };

                _unitOfWork.CommentRepository.CreateComment(comment);
                await _unitOfWork.Save();

                if (comment is not null)
                    return comment.Id;

                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in CreateComment Method" + ex.Message);
                return null;
            }
        }
    }
}
