using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;

namespace Application.App.Comments.Commands.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCommentHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;                
        }

        public async Task<bool> Handle(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            try
            {
                bool response = _unitOfWork.CommentRepository.CreateComment(command.destinationId, command.creatorId, command.text);
                await _unitOfWork.Save();

                if (response)
                    return true;
                else
                    throw new ModificationFailedException("Creating a comment was unsuccessful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in CreateComment Method" + ex.Message);
                return false;
            }
        }
    }
}
