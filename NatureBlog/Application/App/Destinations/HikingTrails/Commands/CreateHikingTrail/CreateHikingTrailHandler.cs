using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    public class CreateHikingTrailHandler : IRequestHandler<CreateHikingTrailCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateHikingTrailHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> Handle(CreateHikingTrailCommand command, CancellationToken cancellationToken)
        {
            try
            {
                User? user = _unitOfWork.UserRepository.GetUser(command.CreatorId);
                if (user is null)
                    throw new UserNotFoundException("No user with the given id found!");

                ICollection<User> visitors = new List<User>();
                visitors.Add(user);

                HikingTrail hikingTrail = new HikingTrail { Name = command.Name, CreatorId = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, RegionId = command.RegionId, Difficulty = command.Difficulty, HikingDuration = command.Duration, Visitors = visitors };

                await _unitOfWork.DestinationRepository.AddHikingTrail(hikingTrail);
                await _unitOfWork.Save();

                if (hikingTrail.Id is null)
                    throw new ModificationFailedException("Destination creation failed!");
                else
                    return hikingTrail.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                throw ex;
            }
        }
    }
}
