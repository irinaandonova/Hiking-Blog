﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Models
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

        public string Text { get; set; }

        public DateTime Date { get; }

        public void ShowComment()
        {
            Console.WriteLine(Date.ToString());
            Console.WriteLine(Creator.Username);
            Console.WriteLine(Text);
        }
    }
}
