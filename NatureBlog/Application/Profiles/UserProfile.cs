using AutoMapper;
using NatureBlog.Application.Dto.User;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserGetDto>();
        }
    }
}
