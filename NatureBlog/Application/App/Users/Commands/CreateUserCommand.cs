using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Users
{
    public class CreateUserCommand : IRequest<User>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }
    }
}
