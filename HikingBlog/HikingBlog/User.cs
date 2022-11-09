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
            try
            {
                Console.WriteLine("Destination name:");
                string name = Console.ReadLine();

                Console.WriteLine("Destination description:");
                string description = Console.ReadLine();

                Console.WriteLine("Destination imageUrl:");
                string imageUrl = Console.ReadLine();

                Console.WriteLine("Destination region:");
                string region = Console.ReadLine();

                Destination destination = new Destination(name, this.Username, description, imageUrl, region);
                return destination;
            }
            catch(NullReferenceException)
            {
                throw new Exception("Fields must be filled");
            }
            catch
            {
                throw new Exception("Difficulty sould be in 1 to 3 range");
            }
        }
    }
}
