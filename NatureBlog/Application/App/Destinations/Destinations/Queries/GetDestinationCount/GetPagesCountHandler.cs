using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using System.Threading.Tasks;

namespace NatureBlog.Application.App.Destinations.Destinations.Queries.GetDestinationCount
{
    public class GetPagesCountHandler : IRequestHandler<GetPagesCountQuery, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPagesCountHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<int> Handle(GetPagesCountQuery query, CancellationToken cancellationToken)
        {
            try
            {
                int count = 0;
                if (query.Type == "all")
                    count = _unitOfWork.DestinationRepository.GetAllDestinationsPagesCount();
                else if (query.Type == "hiking-trails")
                    count = _unitOfWork.DestinationRepository.GetHikingTrailPagesCount();
                else if (query.Type == "parks")
                    count = _unitOfWork.DestinationRepository.GetParkPagesCount();
                else if (query.Type == "seasides")
                    count = _unitOfWork.DestinationRepository.GetSeasidePagesCount();
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
