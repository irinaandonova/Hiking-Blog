using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.HikingTrails.Queries.GetAllHikingTrail
{
    public class GetAllHikingTrailsHandler : IRequestHandler<GetAllHikingTrailsQuery, List<HikingTrail>>
    {
        private readonly IDestinationRepository _repository;

        public GetAllHikingTrailsHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<List<HikingTrail>> Handle(GetAllHikingTrailsQuery query, CancellationToken cancellationToken)
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
