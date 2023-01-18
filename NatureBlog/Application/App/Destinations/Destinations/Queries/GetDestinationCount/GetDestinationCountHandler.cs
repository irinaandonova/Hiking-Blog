using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using System.Threading.Tasks;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetDestinationCount
{
    public class GetDestinationCountHandler : IRequestHandler<GetDestinationCountQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDestinationCountHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(GetDestinationCountQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = 0;
                if (query.Type == "all")
                    count = _unitOfWork.DestinationRepository.GetAllDestinationsCount();
                else if (query.Type == "hiking-trails")
                    count = _unitOfWork.DestinationRepository.GetHikingTrailCount();
                else if (query.Type == "parks")
                    count = _unitOfWork.DestinationRepository.GetParkCount();
                else if (query.Type == "seasides")
                    count = _unitOfWork.DestinationRepository.GetSeasideCount();
                else
                    throw new OutOfRangeException("No such type");

                if (count % 10 == 0)
                    return Task.FromResult(count % 10);
                else
                    return Task.FromResult(count / 10 + 1);
                    
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the GetDestinationCountQuery", ex.Message);
                return Task.FromResult(-1);
            }
        }
    }
}
