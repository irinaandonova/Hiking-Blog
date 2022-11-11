using System;

namespace HikingBlog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                User user = new User("Ira", "ira@", 2);
                Park park = new Park("Layta", user, "Amazing park", "image.com", "Plovdiv", null, null);
                park.CreateComment(user, "Beautiful Park");
                park.ShowComments();
            }
            catch
            {
                Console.WriteLine("Invalid input");
            }
           
            
        }
    }
}
