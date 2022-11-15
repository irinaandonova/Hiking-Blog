using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class User
    {
        public User(string username, string email)
        {                         
                Email = email;
                Username = username;
        }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
