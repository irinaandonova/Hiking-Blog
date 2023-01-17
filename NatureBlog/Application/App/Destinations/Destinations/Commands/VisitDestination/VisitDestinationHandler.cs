using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.VisitDestination
{
    public class VisitDestinationHandler : IRequestHandler<VisitDestinationCommand, List<User>>
    {
        private readonly IUnitOfWork _unitOfwork;

        public VisitDestinationHandler(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public List<User> Handle(VisitDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                /*
                 Destination destination = _unitOfwork.DestinationRepository.GetDestination(command.DestinationId);
                if (destination is null || user is null)
                    return null;
                */
                User user = _unitOfwork.UserRepository.GetUser(command.UserId);

               List<User> visitors= _unitOfwork.DestinationRepository.VisitDestination(user, command.DestinationId);
                //await _unitOfwork.Save();
                
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Visit Destination Method", ex);
                return new List<User>  { };
            }
        }
    }
}
