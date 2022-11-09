using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Comment
    {
        public User Creator;
        public Destination Destination;
        public string Text;
        public DateTime Date;

        public Comment(User creator, Destination destination, string text)
        {
            Creator = creator;
            Destination = destination;
            Text = text;
            Date = DateTime.Now;
        }
    }
}
