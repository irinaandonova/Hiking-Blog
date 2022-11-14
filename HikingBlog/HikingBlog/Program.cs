using HikingBlog.Extensions;
using HikingBlog.Models;
using HikingBlog.Services;
using System;

namespace HikingBlog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WebAPI webApi = new WebAPI();

            User user = new User("Ira", "ira@", 2);
            Park park = new Park("Layta", user, "Amazing park", "image.com", "Plovdiv", true, false);
            park.CreateComment(user, "Beautiful Park");
            park.ShowComments();
            webApi.AddDestination(park);

            Seaside seaside = new Seaside("Konstantin i Elena", user, "Amazing beach", "image1.com", "Varna", true, true);
            seaside.AddUmbrellaPrices(5.00);
            seaside.ShowUmbrellaPrices();
            webApi.AddDestination(seaside);

            HikingTrail hikingTrail = new HikingTrail("Rilski ezera", user, "Krasiva puteka", "sjsj.com", "Rila", 2, 20);
            hikingTrail.RateDestination(1, user);
            webApi.AddDestination(hikingTrail);
            webApi.GetAllDestinations();
        }
    }
}
//Folders models
//Folder services
//Custom exceptions