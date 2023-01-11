using MediatR;
using NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.CreateDestination
{
    public class CreateDestinationHandler : IRequestHandler<CreateDestinationCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDestinationHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> Handle(CreateDestinationCommand command, CancellationToken cancellationToken)
        {
            try
            {
                /*
                Destination destination = new Destination();
                await _unitOfWork.DestinationRepository.AddDestination(destination);
                await _unitOfWork.Save();
                return destination.Id;*/

                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return null;
            }
        }
    }
}
