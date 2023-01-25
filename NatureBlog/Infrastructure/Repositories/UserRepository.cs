using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;

namespace NatureBlog.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _dbContext;

        public UserRepository(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUser(int id)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Id == id);
        }

        public User? GetUser(string email)
        {
            return _dbContext.Users.SingleOrDefault(u => u.Email == email);
        }
        public async Task Add(User user)
        {
             await _dbContext.Users.AddAsync(user);
        }

        public bool Delete(int id)
        {
            User user = GetUser(id);
            if (user is null)
                return false;

            _dbContext.Users.Remove(user);
            return true;
        }
    }
}
