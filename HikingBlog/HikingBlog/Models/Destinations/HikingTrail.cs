using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class HikingTrail : Destination
    {
        public HikingTrail(string name, User creator, string description, string imageUrl, string region, int difficulty, int hikingDuration) : base(name, creator, description, imageUrl, region)
        {
            try
            {
                Exceptions.CheckDifficultyValue(difficulty);
                Difficulty = difficulty;
                Exceptions.CheckDurationValue(hikingDuration);
                HikingDuration = hikingDuration;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

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
                    Difficulty = difficulty;
                else
                    throw new ArgumentOutOfRangeException("Input should be from 1 to 3");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
