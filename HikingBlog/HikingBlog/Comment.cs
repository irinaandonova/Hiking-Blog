using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Comment
    {
        //Id
        private User Creator;
        private string Text;
        private DateTime Date;

        public Comment(User creator, string text)
        {
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
        }
    }
}
