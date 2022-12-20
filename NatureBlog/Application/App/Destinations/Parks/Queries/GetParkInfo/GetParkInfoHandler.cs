using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.Destination.Park;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Parks.Queries.GetParkInfo
{
    public class GetParkInfoHandler : IRequestHandler<GetParkInfoQuery, ParkGetDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetParkInfoHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ParkGetDto> Handle(GetParkInfoQuery command, CancellationToken token)
        {
            try
            {
               Park result =  _unitOfWork.DestinationRepository.GetParkInfo(command.Id);
                if (result == null)
                    return Task.FromResult(new ParkGetDto());

                var mappedResult = _mapper.Map<ParkGetDto>(result);
                return Task.FromResult(mappedResult);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception in the GetParkInfo method", ex);
                return null;
            }
        }
    }
}
