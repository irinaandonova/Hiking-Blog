using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Comments.Commands.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, bool>
    {
        private readonly ICommentRepository _repository;
        private readonly IDestinationRepository _destinationRepository;
        public DeleteCommentHandler(ICommentRepository commentRepository, IDestinationRepository destinationRepository)
        {
            _repository = commentRepository;
            _destinationRepository = destinationRepository;
        }

        public Task<bool> Handle(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _destinationRepository.GetDestination(command.DestinationId);
                Comment comment = destination.Comments.SingleOrDefault(x => x.Id == command.CommentId);
                if (comment is null)
                    throw new CommentNotFoundException("No comment found with the given id!");
                
                if (comment.Creator.Id != command.CreatorId)
                    throw new UserNotCreatorException("Current user isn't the creator of the comment!");
                
                bool response = _repository.DeleteComment(command.DestinationId, command.CommentId);
                if (!response)
                    throw new ModificationFailedException("Creating a comment was unsuccessful!");
                
                return Task.FromResult(true);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Exception in the DeleteComment Method! Insert all values!");
                return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the DeleteComment Method!" + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
