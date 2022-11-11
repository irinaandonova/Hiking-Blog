using HikingBlog.Extensions;
using HikingBlog.Models;
using System;

namespace HikingBlog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Ira", "ira@", 2);
            Park park = new Park("Layta", user, "Amazing park", "image.com", "Plovdiv", null, null);
            park.CreateComment(user, "Beautiful Park");
            park.ShowComments();

            Seaside seaside = new Seaside("Konstantin i Elena", user, "Amazing beach", "image1.com", "Varna", true, true);
            seaside.AddUmbrellaPrices(5.00);
            seaside.ShowUmbrellaPrices();
        }
    }
}
//Folders models
//Folder services
//Custom exceptions