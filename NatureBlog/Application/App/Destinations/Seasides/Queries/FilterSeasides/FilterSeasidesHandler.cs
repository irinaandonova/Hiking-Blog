using NatureBlog.Application.Repositories;
using NatureBlog.Application.Exceptions;
using NatureBlog.Domain.Models;
using NatureBlog.Application.Dto.Destination.Destination;
using AutoMapper;

namespace NatureBlog.Application.Destinations.Seasides.Queries.FilterSeaside
{
    public class FilterSeasidesHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public FilterSeasidesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }

        public Task<List<DestinationGetDto>> Handle(FilterSeasidesQuery query)
        {
            try
            {
                List<DestinationGetDto> seasidesList = _unitOfWork.DestinationRepository.FilterSeaside(query.IsGuarded, query.OffersUmbrellas);

                if (seasidesList.Count() < 0)
                    return Task.FromResult(new List<DestinationGetDto>());

                return Task.FromResult(seasidesList);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in the FilterHikingTrails Method! " + ex.Message);
                return null;
            }
        }
    }
}
