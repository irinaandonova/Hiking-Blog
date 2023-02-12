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
                Comment comment = _unitOfWork.CommentRepository.GetComment(command.CommentId);

                if (destination is null)
                    throw new DestinationNotFoundException("No destination with given id found!");

                if (comment is null)
                    throw new CommentNotFoundException("No comment with given id!");

                if (comment.CreatorId != command.CreatorId)
                    throw new UserNotCreatorException("Current user is not the creator of the comment!");

                bool isRemoved = destination.Comments.Remove(comment);
                if(!isRemoved)
                {
                    throw new ModificationFailedException("Comment unsuccessfully removed from destination comments array!")
                }
                bool response = _unitOfWork.CommentRepository.DeleteComment(command.DestinationId, command.CommentId);
                await _unitOfWork.Save();

                if (!response)
                    throw new ModificationFailedException("Saving changes was unsuccessful!");
                
                return true;
            }
            catch(CommentNotFoundException ex)
            {
                throw ex;
            }
            catch(ModificationFailedException ex)
            {
                throw ex;
            }
            catch (UserNotCreatorException ex)
            {
                throw ex;
            }
            catch (DestinationNotFoundException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the DeleteComment Method!" + ex.Message);
                return false;
            }
        }
    }
}
