using HikingBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikingBlog
{
    internal class Exceptions : Exception
    {
        public Exceptions(string msg) : base(msg)
        { }
        public static User CreateUser(string email, string username)
        {
            if (!email.Contains("a") || username == null)
                throw new Exception("Invalid email or username");
            else
                return new User(username, email);
        }
        public static int CheckDifficultyValue(int difficulty)
        {
            if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                return difficulty;
            else
                throw new ArgumentOutOfRangeException("Difficulty value must be between 1 and 3");
            
        }
        public static int CheckDurationValue(int duration)
        {
            if (duration > 0)
                return duration;
            else
                throw new ArgumentOutOfRangeException("Hiking duretion should be bigger than zero");
        }
        public static List<Destination> CheckCount(List<Destination> destinations)
        {
            if (destinations.Count == 0)
                throw new Exception("No such destinations");
            else
            {
                return destinations;
            }
        }   
    }
}
