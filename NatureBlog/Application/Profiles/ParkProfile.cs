using AutoMapper;
using NatureBlog.Application.Dto.Destination.Park;
using NatureBlog.Domain.Models;

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
