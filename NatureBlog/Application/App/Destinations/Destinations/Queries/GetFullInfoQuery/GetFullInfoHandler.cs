using AutoMapper;
using MediatR;
using NatureBlog.Application.Destinations.AllDestinations.Queries.GetDestination;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetFullInfoQuery
{
    public class GetFullInfoHandler : IRequestHandler<GetFullInfoQuery, DestinationGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetFullInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<DestinationGetDto> Handle(GetFullInfoQuery query, CancellationToken cancellationToken)
        {
            try
            {
                Destination destination = _unitOfWork.DestinationRepository.GetFullInfo(query.Id);
                if (destination is null)
                    throw new DestinationNotFoundException("No destination with given id in database!");

                var mappedResult = _mapper.Map<DestinationGetDto>(destination);
                return Task.FromResult(mappedResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetDestination Method:" + ex.Message);
                return null;
            }
        }
    }
}
