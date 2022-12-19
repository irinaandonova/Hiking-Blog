using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Comments.Commands.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<bool> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _unitOfWork.DestinationRepository.GetDestination(command.DestinationId);
                Comment comment = destination.Comments.SingleOrDefault(x => x.Id == command.CommentId);

                if (comment is null)
                    throw new CommentNotFoundException("No comment found with the given id!");
                
                if (comment.Creator.Id != command.CreatorId)
                    throw new UserNotCreatorException("Current user isn't the creator of the comment!");
                
                bool response = _unitOfWork.CommentRepository.DeleteComment(command.DestinationId, command.CommentId);
                await _unitOfWork.Save();

                if (!response)
                    throw new ModificationFailedException("Creating a comment was unsuccessful!");
                
                return true;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Exception in the DeleteComment Method! Insert all values!");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the DeleteComment Method!" + ex.Message);
                return false;
            }
        }
    }
}
