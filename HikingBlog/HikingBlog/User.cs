using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class User
    {
        public string Username;
        public string Email;
        public int HikingLevel;

        public User(string username, string email, int hikingLevel)
        {
            Username = username;
            if (!email.Contains("@")) throw new Exception("Invalid email");
            Email = email;
            if(hikingLevel == 1 || hikingLevel == 2 || hikingLevel == 3)
            {
                HikingLevel = hikingLevel;
            }
            else
            {
                throw new Exception("Invalid hiking level");
            }
        }
        public Park CreatePark()
        {
                Console.WriteLine("Destination name:");
                string name = Console.ReadLine();

                Console.WriteLine("Destination description:");
                string description = Console.ReadLine();

                Console.WriteLine("Destination imageUrl:");
                string imageUrl = Console.ReadLine();

                Console.WriteLine("Destination region:");
                string region = Console.ReadLine();

                bool? hasPlayground;
                char key;
                Console.WriteLine("Does park have playground y/n");
                key = Console.ReadKey().KeyChar;

                if (key == 'y')
                  hasPlayground = true;
                else if (key == 'n')
                  hasPlayground = false;
                else
                  hasPlayground = null;

                bool? isDogFriendly;
                Console.WriteLine("Is park dog friendly y/n");
                key = Console.ReadKey().KeyChar;

                if (key == 'y')
                  isDogFriendly = true;
                else if (key == 'n')
                  isDogFriendly = false;
                else
                  isDogFriendly = null;

                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(description) || String.IsNullOrEmpty(imageUrl) || String.IsNullOrEmpty(region))
                {
                    throw new Exception("All fields must be filled!");
                }
            
                Park park = new Park(name, this.Username, description, imageUrl, region, hasPlayground, isDogFriendly);
                return park;
        }
        
        /*
        public HikingTrail CreateHikingTrail(Destination destination)
        {
            if (difficulty != 1 || difficulty != 2 || difficulty != 3)
                throw new Exception("Difficulty value must be between 1 and 3");

            HikingTrail hikingTrail = new HikingTrail(destination.name, destination.creator, destination.description, destination.imageUrl, destination.region, difficulty, hikingDuration);
            return hikingTrail;
        }
        */

        
    }
}
