using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    internal class GetAllHikingTrailsHandler
    {
        private readonly IDestinationRepository _repository;

        public GetAllSeasidesHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<List<HikingTrail>> Handle(GetAllHikingTrailsCommand command, CancellationToken cancellationToken)
        {
            try
            {
                List<HikingTrail> allHikingTrails = _repository.GetAllHikingTrails();

                if (allHikingTrails.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                return Task.FromResult(allHikingTrails);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetHikingTrails Method:" + ex.Message);
                return null;
            }
        }
    }
}
