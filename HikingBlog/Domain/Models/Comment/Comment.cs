using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Domain.Models
{
    public class Comment 
    {
        public int Id { get; set; } 

        public User Creator { get; set; }

        public string Text { get; set; }

        public DateTime Date { get; set; }

        public Destination Destination { get; set; }

    }
}
