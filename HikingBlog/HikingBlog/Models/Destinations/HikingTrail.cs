using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
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

        public void ChangeDifficulty()
        {
            int difficulty;
            try
            {
                bool result = Int32.TryParse(Console.ReadLine(), out difficulty);
                if (!result)
                    throw new FormatException("Incorrect input");
                if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                    Difficulty= difficulty;
                else
                    throw new ArgumentOutOfRangeException("Input should be from 1 to 3");
            }
            catch(FormatException)
            {
                throw new FormatException("Input is not an integer number");
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}
