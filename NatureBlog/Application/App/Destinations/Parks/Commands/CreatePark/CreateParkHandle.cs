using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Commands.CreatePark
{
    public class CreateParkHandler : IRequestHandler<CreateParkCommand, int?>
    {
        private readonly IUnitOfWork _unitOfWork;


        public CreateParkHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int?> Handle(CreateParkCommand command, CancellationToken cancellationToken)
        {
            try
            {
                Park park = new Park { Name = command.Name, Creator = command.Creator, Description = command.Description, ImageUrl = command.ImageUrl, Region = command.Region, HasPlayground = command.HasPlayground, IsDogFriendly = command.IsDogFriendly };
                await _unitOfWork.DestinationRepository.AddPark(park);
                await _unitOfWork.Save();

                return park.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return 0;
            }
        }
    }
}
