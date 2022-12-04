using Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.AllDestinations.Queries.GetDestination
{
    internal class GetDestinationHandler: IRequestHandler<GetDestinationQuery, Destination>
    {
        private readonly IDestinationRepository _repository;

        public GetDestinationHandler(IDestinationRepository DestinationRepository)
        {
            _repository = DestinationRepository;
        }

        public Task<Destination> Handle(GetDestinationQuery query, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _repository.GetDestination(query.Id);
                if (destination is null)
                    throw new DestinationNotFoundException("No destination with given id in database!");

                return Task.FromResult(destination);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetDestination Method:" + ex.Message);
                return null;
            }
        }
    }
}
