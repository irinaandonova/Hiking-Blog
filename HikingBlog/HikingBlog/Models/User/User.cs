using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class User
    {
        public User(string username, string email)
        {
            try
            {
                Username = username;
                Email = CustomException.InvalidEmail(email);
                Email = email;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
