using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    internal class CustomException: Exception
    {
        public CustomException(string msg) : base(msg)
        { }
        public static string InvalidEmail(string email)
        {
            if (!email.Contains('@'))
                throw new Exception("Invalid email");
            else
                return email;               
        }

    }
}
