using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class User
    {
        public User(string username, string email, int hikingLevel)
        {
            try
            {
                Username = username;
                Email = CustomException.InvalidEmail(email);
                Email = email;
                if (hikingLevel == 1 || hikingLevel == 2 || hikingLevel == 3)
                {
                    HikingLevel = hikingLevel;
                }
                else
                {
                    throw new Exception("Invalid hiking level");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public string Username { get; set; }
        public string Email { get; set; }
        public int HikingLevel { get; set; }
    }
}
