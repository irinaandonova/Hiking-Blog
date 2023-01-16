using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Comments.Commands.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool?>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<bool?> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _unitOfWork.DestinationRepository.GetDestination(command.DestinationId);
                Comment comment = _unitOfWork.CommentRepository.GetComment(command.CommentId);
                
                if (destination is null || comment is null)
                    return null;

                if (comment.CreatorId != command.CreatorId)
                    return null;

                destination.Comments.Remove(comment);
                bool response = _unitOfWork.CommentRepository.DeleteComment(command.DestinationId, command.CommentId);
                await _unitOfWork.Save();

                if (!response)
                    throw new ModificationFailedException("Creating a comment was unsuccessful!");
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the DeleteComment Method!" + ex.Message);
                return false;
            }
        }
    }
}
