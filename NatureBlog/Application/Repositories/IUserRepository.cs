using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IUserRepository
    {
        User GetUser(int id);

        Task Add(User user);

        bool Delete(int id);
    }
}
