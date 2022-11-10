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
        public Destination CreateDestination()
        {
                Console.WriteLine("Destination name:");
                string name = Console.ReadLine();

                Console.WriteLine("Destination description:");
                string description = Console.ReadLine();

                Console.WriteLine("Destination imageUrl:");
                string imageUrl = Console.ReadLine();

                Console.WriteLine("Destination region:");
                string region = Console.ReadLine();

            Console.WriteLine(name);

              if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(description) || String.IsNullOrEmpty(imageUrl) || String.IsNullOrEmpty(region))
                {
                    throw new Exception("All fields must be filled!");
                }
            
            Destination destination = new Destination(name, this.Username, description, imageUrl, region);
                return destination;
        }
    }
}
