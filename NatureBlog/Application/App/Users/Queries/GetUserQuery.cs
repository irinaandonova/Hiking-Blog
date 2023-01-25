using MediatR;
using NatureBlog.Application.Dto.User;

namespace NatureBlog.Application.App.Users.Queries
{
    public class GetUserQuery : IRequest<UserGetDto>
    {
        public string Email { get; set; }
    }
}
