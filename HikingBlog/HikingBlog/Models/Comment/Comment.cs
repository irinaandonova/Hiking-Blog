using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class Comment
    {
        public Comment(User creator, string text)
        {
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
            Id = Creator.Username + Date.ToString();
        }
        public string Id { get; }

        public User Creator { get; }

        public string Text { get; }

        public DateTime Date { get; }

        public void ShowComment()
        {
            Console.WriteLine(Date.ToString());
            Console.WriteLine(Creator.Username);
            Console.WriteLine(Text);
        }
    }
}
