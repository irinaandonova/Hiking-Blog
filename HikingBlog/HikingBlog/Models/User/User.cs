using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class User
    {
        public User(string username, string email, int hikingSkill)
        {
            Email = email;
            Username = username;
            HikingSkill = hikingSkill;
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public int HikingSkill { get; set; }
    }
}
