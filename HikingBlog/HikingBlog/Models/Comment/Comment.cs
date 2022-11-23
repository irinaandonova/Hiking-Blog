using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Models
{
    public class Comment
    {
        public Comment(User creator, string text, Destination destination)
        {
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
            Id = Creator.Username + Date.ToString();
            Destination = destination;  
        }
        public string Id { get; }

        public User Creator { get; }

        public string Text { get; set; }

        public DateTime Date { get; }

        public Destination Destination { get; set; }    
    }
}
