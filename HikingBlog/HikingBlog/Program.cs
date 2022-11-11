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
            catch
            {
                Console.WriteLine("Invalid input");
            }
           
            
        }
    }
}
