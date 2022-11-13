using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class Destination
    {
        public Destination(string name, User creator, string description, string imageUrl, string region)
        {
            Name = name;
            Creator = creator;
            Description = description;
            ImageUrl = imageUrl;
            Region = region;
        }

        public string Name { get; set; }
        public User Creator { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Region { get; set; }
        public Dictionary<string, Comment> Comments = new Dictionary<string, Comment> { };
        public Dictionary<User, int> Ratings = new Dictionary<User, int> { };
    }
}
