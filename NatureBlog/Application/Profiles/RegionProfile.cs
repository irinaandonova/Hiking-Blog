using Application.Dto.Region;
using AutoMapper;
using NatureBlog.Application.Dto.Region;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<RegionPostDto, Region>();
            CreateMap<ICollection<Region>, RegionGetDto>();
            //CreateMap<Region, RegionGetDto>();
        }
    }
}
