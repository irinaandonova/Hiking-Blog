using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models.Destinations
{
    public class HikingTrail : Destination
    {
        public HikingTrail(string name, User creator, string description, string imageUrl, string region, int difficulty, int hikingDuration) : base(name, creator, description, imageUrl, region)
        {
            if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                Difficulty = difficulty;
            else
                throw new Exception("Difficulty value must be between 1 and 3");

            HikingDuration = hikingDuration;
        }
        public int Difficulty { get; set; }
        public int HikingDuration { get; set; }
    }
}
