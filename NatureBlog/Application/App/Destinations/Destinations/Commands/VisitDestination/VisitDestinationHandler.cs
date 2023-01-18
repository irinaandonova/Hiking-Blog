using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.VisitDestination
{
    public class VisitDestinationHandler : IRequestHandler<VisitDestinationCommand, bool>
    {
        private readonly IUnitOfWork _unitOfwork;

        public VisitDestinationHandler(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task<bool> Handle(VisitDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _unitOfwork.DestinationRepository.GetDestination(command.DestinationId);
                User user = _unitOfwork.UserRepository.GetUser(command.UserId);

                _unitOfwork.DestinationRepository.VisitDestination(user, destination);
                await _unitOfwork.Save();
                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Visit Destination Method", ex);
                return false;
            }
        }
    }
}
