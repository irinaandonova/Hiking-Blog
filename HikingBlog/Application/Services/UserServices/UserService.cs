using NatureBlog.Database;
using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Services.UserServices
{
    internal class UserService
    {
        private readonly Dictionary<Guid, User> users;

        public UserService()
        {
            this.users = UserList.GetInstance().AllUsers;
        }

        

    }
}
