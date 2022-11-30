using MediatR;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetMostVisited;
using NatureBlog.Application.Destinations.Interfaces;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.AllDestinations.Queries.GetMostVisited
{
    internal class GetMostVisitedHandler : IRequestHandler<GetMostVisitedCommand, List<Destination>>
    {
        private readonly IDestinationRepository _repository;

        public GetMostVisitedHandler(IDestinationRepository destinationRepository)
        {
            _repository= destinationRepository;
        }

        public Task<List<Destination>> Handle(GetMostVisitedCommand command, CancellationToken cancellationToken) 
        {
            try 
            {
                List<Destination> result = _repository.GetMostVisited();
                if (result.Count < 1)
                    throw new DestinationNotFoundException("No destinations in database!");

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
