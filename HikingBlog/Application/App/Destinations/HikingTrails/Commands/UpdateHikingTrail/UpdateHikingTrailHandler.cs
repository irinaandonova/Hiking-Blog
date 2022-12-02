using Application.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.HikingTrails.Commands.UpdateHikingTrail
{
    internal class UpdateHikingTrailHandler
    {
        public readonly IDestinationRepository _repository;

        public UpdateHikingTrailHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<bool> Handle(UpdateHikingTrailCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = (HikingTrail)_repository.GetDestination(command.Id);

                if (hikingTrail is null)
                    throw new DestinationNotFoundException("No destination with given id");
                if (hikingTrail.Creator == command.user)
                    _repository.Update(command.Id, command.hikingTrail);
                else
                    throw new UserNotCreatorException("The current user isn't the creator of the destination");

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Delete Method:" + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
