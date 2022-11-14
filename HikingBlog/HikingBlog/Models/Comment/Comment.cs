using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class Comment
    {
        public Comment(User creator, string text)
        {
            CustomException.CheckUser(creator);
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
            Id = Creator.Username + Date.ToString();
        }
        public string Id { get; set; }
        public User Creator { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
    }
}
