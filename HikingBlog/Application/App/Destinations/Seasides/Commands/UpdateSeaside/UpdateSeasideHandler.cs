using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.UpdateSeaside
{
    public class UpdateSeasideHandler : IRequestHandler<UpdateSeasideCommand, bool>
    {
        public readonly IDestinationRepository _repository;

        public UpdateSeasideHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<bool> Handle(UpdateSeasideCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Seaside seaside = (Seaside)_repository.GetDestination(command.Id);

                if (seaside is null)
                    throw new DestinationNotFoundException("No destination with given id");
                if (seaside.Creator == command.user)
                    _repository.Update(command.Id, command.seaside);
                else
                    throw new DestinationNotFoundException("No destination with given id!");

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
