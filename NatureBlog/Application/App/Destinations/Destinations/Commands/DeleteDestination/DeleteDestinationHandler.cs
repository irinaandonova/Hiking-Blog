using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

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
                Destination destination = _unitOfWork.DestinationRepository.GetDestination(command.DestinationId);
                if (destination.CreatorId != command.UserId)
                    throw new UserNotCreatorException("Current user not creator of the destination!");

                _unitOfWork.DestinationRepository.Delete(command.DestinationId);
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
