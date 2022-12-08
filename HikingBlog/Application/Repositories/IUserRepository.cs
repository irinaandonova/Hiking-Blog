using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);
    }
}
