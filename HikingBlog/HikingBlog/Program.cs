using HikingBlog;
using HikingBlog.Extensions;
using HikingBlog.Models;
using HikingBlog.Services;
using System;
using System.IO;

try
{
    WebAPI webApi = new WebAPI();
    //var ms = new MemoryStream(); 
    User user = new User("irina", "irina@");
    Park park = new Park("Layta", user, "Amazing park", "image.com", "Plovdiv", true, false);
    park.CreateComment(user, "Beautiful Park");
    park.ShowComments();
    var download = new DownloadDestination();
    download.SaveDestination(park);
    HikingTrail hikingTrail = new HikingTrail("Rila lakes", user, "Beautiful trail", "sjsj.com", "Rila", 2, 20);
    hikingTrail.ShowFullInformation();
    
    //download.CompressStream(park);
    //download.Decompress();
    /*
    webApi.AddDestination(park);

    Seaside seaside = new Seaside("Konstantin and Elena", user, "Amazing beach", "image1.com", "Varna", true, true);
    seaside.AddUmbrellaPrices(5.00);
    seaside.ShowUmbrellaPrices();
    webApi.AddDestination(seaside);
    //webApi.GetAllSeaside();
    
    hikingTrail.ShowFullInformation();
    
    webApi.GetFirstTen();
    */
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
