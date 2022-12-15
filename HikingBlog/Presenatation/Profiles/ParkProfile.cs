using AutoMapper;
using NatureBlog.Domain.Models;
using Presenatation.Dto.Destination.Park;

namespace NatureBlog.Presenatation.Profiles
{
    public class ParkProfile : Profile
    {
        public ParkProfile()
        {
            CreateMap<ParkPostDto, Park>();
            CreateMap<Park, ParkGetDto>();
        }
    }
}
