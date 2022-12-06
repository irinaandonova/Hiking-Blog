﻿using MediatR;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    public class CreateHikingTrailHandler : IRequestHandler<CreateHikingTrailCommand, Guid>
    {
        private readonly IDestinationRepository _DestinationRepository;

        public CreateHikingTrailHandler(IDestinationRepository DestinationRepository)
        {
            _DestinationRepository = DestinationRepository;
        }

        public Task<Guid> Handle(CreateHikingTrailCommand command, CancellationToken cancellationToken)
        {
            try
            {
                HikingTrail hikingTrail = new HikingTrail { Name = command.Name, Creator = command.CreatorId, Description = command.Description, ImageUrl = command.ImageUrl, Region = command.Region, Difficulty = command.Difficulty, HikingDuration = command.Duration };
                _DestinationRepository.Add(hikingTrail);

                return Task.FromResult(hikingTrail.Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in Add Method:" + ex.Message);
                return Task.FromResult(Guid.Empty);
            }
        }
    }
}
