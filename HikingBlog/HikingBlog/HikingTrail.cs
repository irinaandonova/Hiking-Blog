using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class HikingTrail: Destination
    {
        private int Difficulty;
        private int HikingDuration;
        public HikingTrail(string name, string creator, string description, string imageUrl, string region, int difficulty, int hikingDuration): base(name, creator, description, imageUrl, region)
        {
            if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                Difficulty = difficulty;
            else
                throw new Exception("Difficulty value must be between 1 and 3");
            HikingDuration = hikingDuration;
        }

    }
}
