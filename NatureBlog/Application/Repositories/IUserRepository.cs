using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IUserRepository
    {
        User? GetUser(int id);

        User? GetUser(string email);

        Task Add(User user);

        bool Delete(int id);
    }
}
