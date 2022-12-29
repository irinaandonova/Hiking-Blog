using NatureBlog.Application.Repositories;
using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.Seaside;
using AutoMapper;

namespace NatureBlog.Application.Destinations.Seasides.Queries.GetAllSeaside
{
    public class GetAllSeasidesHandler : IRequestHandler<GetAllSeasidesQuery, List<SeasideGetDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllSeasidesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<List<SeasideGetDto>> Handle(GetAllSeasidesQuery query, CancellationToken cancellationToken)
        {
            try
            {
                List<Seaside> allSeasides = _unitOfWork.DestinationRepository.GetAllSeasides();

                if (allSeasides.Count() < 0)
                    return Task.FromResult(new List<SeasideGetDto>());

                var mappedResult = _mapper.Map<List<SeasideGetDto>>(allSeasides);
                return Task.FromResult(mappedResult);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Exception in GetAllSeasides Method:" + ex.Message);
                return null;
            }
        }
    }
}
