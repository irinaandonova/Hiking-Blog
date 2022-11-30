using MediatR;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.HikingTrails.Queries.FilterHikingTrails
{
    public class FilterHikingTrailsHandler : IRequestHandler<FilterHikingTrailsCommand, List<HikingTrail>>
    {
        private readonly IDestinationRepository _repository;

        public FilterHikingTrailsHandler(IDestinationRepository destinationRepository)
        {
            _repository = destinationRepository;
        }

        public Task<List<HikingTrail>> Handle(FilterHikingTrailsCommand command)
        {
            try
            {
                List<HikingTrail> hikingTrailsList = _repository.FilterHikingTrails(command.difficulty);

                if (hikingTrailsList.Count() < 0)
                    throw new DestinationNotFoundException("There are no hiking trail elements that fullfil the condition in the collection");

                return Task.FromResult(hikingTrailsList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterHikingTrails Method" + ex.Message);
                return null;
            }
        }
    }
}
