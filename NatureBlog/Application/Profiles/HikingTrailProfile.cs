using AutoMapper;
using NatureBlog.Application.Dto.Destination.HikingTrail;
using NatureBlog.Domain.Models;

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
