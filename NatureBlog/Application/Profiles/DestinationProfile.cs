using AutoMapper;
using NatureBlog.Application.Dto.Destination.Destination;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class DestinationProfile : Profile
    {
        public DestinationProfile()
        {
            CreateMap<HikingTrail, DestinationGetDto>();
            CreateMap<Seaside, DestinationGetDto>();
            CreateMap<Park, DestinationGetDto>();
        }
    }
}
