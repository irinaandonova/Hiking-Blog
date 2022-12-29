using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<User>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }
    }
}
