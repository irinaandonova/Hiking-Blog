using System;

namespace HikingBlog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User("Ira", "ira@", 5);
            }
            catch()
            {
                Console.WriteLine("")
            }
            try
            {
                Destination destination = user.CreateDestination();
            }
            catch
            {
                Console.WriteLine("All fields must be filled!");
                Destination destination = user.CreateDestination();
            }
            
        }
    }
}
