using AutoMapper;
using NatureBlog.Application.Dto.Comment;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment,CommentGetDto>();
        }
    }
}
