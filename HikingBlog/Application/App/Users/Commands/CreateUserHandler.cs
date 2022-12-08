using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (String.IsNullOrEmpty(command.Username) || String.IsNullOrEmpty(command.Email))
                    throw new AllFieldsMustBeFilled("Username or email isn't filled!");
                if (command.HikingSkill < 1 || command.HikingSkill > 3)
                    throw new OutOfRangeException("Hiking level must be between 1 and 3!");

                User user = new User { Id = Guid.NewGuid(), Username = command.Username, Email = command.Email, HikingSkill = command.HikingSkill};
                _userRepository.Add(user);

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excetion in the Add User method: ", ex.Message);
                return Task.FromResult(false);
            }
        }
    }
        
}


