using AutoMapper;
using NatureBlog.Application.Dto.Destination.Seaside;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class SeasideProfile: Profile
    {
        public SeasideProfile() 
        {
            CreateMap<SeasidePostDto, Seaside>();
            CreateMap<Seaside, SeasideGetDto>();

        }
    }
}
