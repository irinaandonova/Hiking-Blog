using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Destination
    {
        public string Name;
        public string Creator;
        public int Difficulty;
        public string Description;
        public decimal Rating;
        public string ImageUrl;
        public string Region;
        public int Duration;
        public Destination(string name, string creator, int difficulty, string description, string imageUrl, string region, int duration)
        {
            Name = name;
            Creator = creator;
            Difficulty = difficulty;
            Description = description;
            ImageUrl = imageUrl;
            Region = region;
            Duration = duration;
        }
    }
}
