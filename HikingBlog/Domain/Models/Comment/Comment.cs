using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Domain.Models
{
    public class Comment 
    {
        public readonly Guid Id;

        public Comment(Guid creator, string text, Guid destination)
        {
            Id = Guid.NewGuid();
            Creator = creator;
            Text = text;
            Date = DateTime.Now;
            Destination = destination;
        }

        public Guid Creator { get; }

        public string Text { get; set; }

        public DateTime Date { get; }

        public Guid Destination { get; set; }

    }
}
