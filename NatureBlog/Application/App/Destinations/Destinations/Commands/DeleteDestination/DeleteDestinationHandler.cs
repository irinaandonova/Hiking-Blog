using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;

namespace NatureBlog.Application.Destinations.AllDestinations.Commands.DeleteDestination
{

    public class DeleteDestinationHandler : IRequestHandler<DeleteDestinationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDestinationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public async Task<bool> Handle(DeleteDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                _unitOfWork.CommentRepository.DeleteComment(command.Id, command.DestonationId);
                await _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Delete Method:" + ex.Message);
                return false;
            }
        }
    }
}
