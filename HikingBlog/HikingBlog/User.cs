using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class User
    {       
        public User(string username, string email, int hikingLevel)
        {
            Username = username;
            if (!email.Contains("@")) throw new Exception("Invalid email");
            Email = email;
            if(hikingLevel == 1 || hikingLevel == 2 || hikingLevel == 3)
            {
                HikingLevel = hikingLevel;
            }
            else
            {
                throw new Exception("Invalid hiking level");
            }
        }
        public string Username { get; set; }   
        public string Email { get; set; }
        public int HikingLevel { get; set; }
    }
}
