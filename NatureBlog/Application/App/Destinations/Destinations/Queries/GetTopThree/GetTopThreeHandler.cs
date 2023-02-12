using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetTopThree
{
    public class GetTopThreeHandler : IRequestHandler<GetTopThreeQuery, List<DestinationGetDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetTopThreeHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<List<DestinationGetDto>> Handle(GetTopThreeQuery command, CancellationToken cancellationToken) 
        {
            try
            {
                List<Destination> destinations = _unitOfWork.DestinationRepository.GetTopThree();
                var result = _mapper.Map<List<DestinationGetDto>>(destinations);

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the Get Top Three Method", ex.Message);
                return null;
            }
            
        }
    }
}
