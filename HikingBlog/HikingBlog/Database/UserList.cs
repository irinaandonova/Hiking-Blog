using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Database
{
    public class UserList
    {
        private UserList()
        { }

        private static UserList _instance;

        private static readonly object _lock = new object();

        public static UserList GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserList();
                        _instance.AllUsers = new List<User> { };
                    }
                }
            }
            return _instance;
        }

        public List<User> AllUsers;
    }
}
