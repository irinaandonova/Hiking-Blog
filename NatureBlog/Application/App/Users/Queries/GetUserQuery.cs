using AutoMapper;
using MediatR;
using NatureBlog.Application.Dto.User;
using NatureBlog.Application.Repositories;

namespace NatureBlog.Application.App.Users.Queries
{
    public class GetUserQuery : IRequest<UserGetDto>
    {
        public int Id { get; set; }
    }
}
