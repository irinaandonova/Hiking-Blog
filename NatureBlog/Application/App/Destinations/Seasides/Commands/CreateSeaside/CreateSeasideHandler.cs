using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Exceptions;

namespace NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside
{
    public class CreateSeasideHandler : IRequestHandler<CreateSeasideCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSeasideHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> Handle(CreateSeasideCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = _unitOfWork.UserRepository.GetUser(command.CreatorId);
                if (user is null)
                    throw new UserNotFoundException("No user with given id");

                ICollection<User> visitors = new List<User>();
                visitors.Add(user);

                Seaside seaside = new Seaside { Name = command.Name, CreatorId = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, RegionId = command.RegionId, OffersUmbrella = command.OffersUmbrella, IsGuarded= command.IsGuarded, Visitors = visitors };
                
                await _unitOfWork.DestinationRepository.AddSeaside(seaside);
                await _unitOfWork.Save();

                return seaside.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                throw ex;
            }
        }
    }
}
