using NatureBlog.Database;
using NatureBlog.Exceptions;
using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Models
{
    public class User : ISubscriber
    {
        public User(string username, string email, int hikingSkill)
        {
            Email = email;
            Username = username;
            HikingSkill = hikingSkill;
            UserList.GetInstance().AllUsers.Add(this);
            if (!UserList.GetInstance().AllUsers.Contains(this))
                throw new UserNotFoundException("User creation failed!");
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }

        public bool IsSubscribed { get; set; } = false;

    }
}
