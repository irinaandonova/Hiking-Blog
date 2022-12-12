using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Parks.Commands.UpdateHasPlaygroundField
{
    public class UpdateHasPlaygroundHandler : IRequestHandler<UpdateHasPlaygroundCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateHasPlaygroundHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateHasPlaygroundCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Park park =  (Park)_unitOfWork.DestinationRepository.GetDestination(command.DestinationId);

                if (park.Creator.Id != command.UserId)
                    throw new UserNotCreatorException("Current user didn't create this destination!");
               

                _unitOfWork.DestinationRepository.UpdatePlayground(command.DestinationId, command.HasPlayground);
                await _unitOfWork.Save();

                if (park.HasPlayground != command.HasPlayground)
                    throw new ModificationFailedException("Playground change failed!");

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the UpdateHasPlayground Method! " + ex.Message);
                return false;
            }
        }
    }
}
