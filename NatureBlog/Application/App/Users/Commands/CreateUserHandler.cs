using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Users
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<User> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                if (String.IsNullOrEmpty(command.Username) || String.IsNullOrEmpty(command.Email))
                    throw new AllFieldsMustBeFilled("Username or email isn't filled!");
                if (command.HikingSkill < 1 || command.HikingSkill > 3)
                    throw new OutOfRangeException("Hiking level must be between 1 and 3!");

                User user = new User {  Username = command.Username, Email = command.Email, HikingSkill = command.HikingSkill};

                await _unitOfWork.UserRepository.Add(user);
                await _unitOfWork.Save();

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excetion in the Add User method: ", ex.Message);
                return null;
            }
        }
    }
        
}


