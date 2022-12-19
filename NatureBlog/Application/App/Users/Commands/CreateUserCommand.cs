using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.App.Users
{
    public class CreateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }
    }
}
