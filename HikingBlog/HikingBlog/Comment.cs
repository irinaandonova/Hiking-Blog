using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Comment
    {
        public string Id; 
        private User Creator;
        public string Text;
        private DateTime Date;

        public Comment(User creator, string text)
        {
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
            Id = Creator.Username + Date.ToString();
        }
    }
}
