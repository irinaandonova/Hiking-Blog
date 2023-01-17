﻿using NatureBlog.Application.Repositories;
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
                User user = _unitOfWork.UserRepository.GetUser(command.CreatorId);
                ICollection<User> visitors = new List<User>();
                visitors.Add(user);

                Park park = new Park { Name = command.Name, CreatorId = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, RegionId = command.RegionId, HasPlayground = command.HasPlayground, IsDogFriendly = command.IsDogFriendly, Visitors = visitors };
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
