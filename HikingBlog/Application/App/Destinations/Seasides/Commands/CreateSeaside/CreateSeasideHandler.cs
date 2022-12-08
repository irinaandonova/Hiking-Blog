using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside
{
    public class CreateSeasideHandler : IRequestHandler<CreateSeasideCommand, bool>
    {
        private readonly IDestinationRepository _repository;

        public CreateSeasideHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<bool> Handle(CreateSeasideCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Seaside seaside = new Seaside { Name = command.Name, Creator = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, Region = command.Region, OffersUmbrella = command.OffersUmbrella, IsGuarded= command.IsGuarded };
                //_repository.Add(seaside);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return Task.FromResult(false);
            }
        }
    }
}
