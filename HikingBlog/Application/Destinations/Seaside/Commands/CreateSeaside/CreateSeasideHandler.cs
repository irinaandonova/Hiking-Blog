using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Destinations.Seasides.Commands.CreateDestination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.CreateDestination
{
    public class CreateSeasideHandler : IRequestHandler<CreateSeasideCommand, Guid>
    {
        private readonly IDestinationRepository _DestinationRepository;

        public CreateSeasideHandler(IDestinationRepository DestinationRepository)
        {
            _DestinationRepository = DestinationRepository;
        }

        public Task<Guid> Handle(CreateSeasideCommand command, CancellationToken cancellationToken)
        {
            Seaside seaside = new Seaside(command.Name, command.Creator, command.Description, command.ImageUrl, command.Region, command.IsGuarded, command.OffersUmbrella);

            return Task.FromResult(seaside.Id); 
        }
    }
}
