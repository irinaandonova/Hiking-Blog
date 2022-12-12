﻿using MediatR;
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
                HikingTrail hikingTrail = new HikingTrail { Name = command.Name, Creator = command.Creator, Description = command.Description, ImageUrl = command.ImageUrl, Region = command.Region, Difficulty = command.Difficulty, HikingDuration = command.Duration };
                
                await _unitOfWork.DestinationRepository.AddHikingTrail(hikingTrail);
                await _unitOfWork.Save();
                return hikingTrail.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return null;
            }
        }
    }
}
