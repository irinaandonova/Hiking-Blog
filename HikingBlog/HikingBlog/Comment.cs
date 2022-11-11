using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Comment
    {
        public User Creator;
        public string Text;
        public DateTime Date;

        public Comment(User creator, string text)
        {
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
        }
    }
}
