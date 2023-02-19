using MediatR;
using NatureBlog.Application.Exceptions;
using NatureBlog.Application.Repositories;

namespace NatureBlog.Application.App.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            try
            {
                bool result = _unitOfWork.UserRepository.Delete(command.Id);
                if (result == false)
                    throw new ModificationFailedException("User wasn't deleted!");

                await _unitOfWork.Save();
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Delete user method: ", ex.Message);
                throw ex;
            }
        }
    }
}
