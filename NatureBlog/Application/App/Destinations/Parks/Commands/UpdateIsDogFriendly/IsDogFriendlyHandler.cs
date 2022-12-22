using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Parks.Commands.UpdateIsDogFriendly
{
    public class IsDogFriendlyHandler : IRequestHandler<IsDogFriendlyCommand, bool?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public IsDogFriendlyHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool?> Handle(IsDogFriendlyCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Destination park = _unitOfWork.DestinationRepository.GetDestination(command.DestinationId);
                if (park is null)
                    return null;
                if (park.CreatorId != command.UserId)
                    return null;

                _unitOfWork.DestinationRepository.UpdateIsDogFriendly(command.DestinationId, command.IsDogFriendly);
                await _unitOfWork.Save();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception in UpdateIsDogFriendly method: ", ex.Message);
                return false;
            }
        }
    }
}
