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
                Email = CustomException.InvalidEmail(email);
                Email = email;
                Username = username;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
