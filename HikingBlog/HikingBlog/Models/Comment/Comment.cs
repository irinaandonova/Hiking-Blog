using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Models
{
    public class Comment
    {
        public readonly Guid Id;

        public Comment(User creator, string text, Destination destination)
        {
            Id = Guid.NewGuid();
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
            Destination = destination;
        }

        public User Creator { get; }

        public string Text { get; set; }

        public DateTime Date { get; }

        public Destination Destination { get; set; }

    }
}
