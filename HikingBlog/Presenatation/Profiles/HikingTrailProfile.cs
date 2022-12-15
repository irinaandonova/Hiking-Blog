using AutoMapper;
using NatureBlog.Domain.Models;
using NatureBlog.Presenatation.Dto.Destination;

namespace NatureBlog.Presenatation.Profiles
{
    public class HikingTrailProfile : Profile
    {
        public HikingTrailProfile()
        {
            CreateMap<HikingTrailPostDto, HikingTrail>();
            CreateMap<HikingTrail, HikingTrailGetDto>();
        }
    }
}
