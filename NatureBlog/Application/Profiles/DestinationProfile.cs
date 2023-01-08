using AutoMapper;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<Destination, DestinationGetDto>()
                .ForMember(m => m.Type, options => options.MapFrom(destination => destination.GetType()));
            CreateMap<HikingTrail, DestinationGetDto>();
            CreateMap<Seaside, DestinationGetDto>();
            CreateMap<Park, DestinationGetDto>();
        }
    }
}
