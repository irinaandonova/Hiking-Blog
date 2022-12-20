using NatureBlog.Application.Repositories;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }
        public async Task Add(User user)
        {
             await _dbContext.Users.AddAsync(user);
        }

        public bool Delete(int id)
        {
            User user = GetUser(id);
            _dbContext.Users.Remove(user);
            
            return true;
        }
    }
}
