using NatureBlog;
using NatureBlog.Database;
using NatureBlog.Models;
using NatureBlog.Services;
using NatureBlog.Services.DestinationServices;
using System;
using System.IO;
using System.Xml.Linq;

try
{
     
    User user = new User("irina", "irina@", 2);
    Park park = new Park("Layta", user, "Amazing park", "image.com", "Plovdiv", true, false);
    Park park1 = new Park("Laytssa", user, "Amazing park", "image.com", "Plovdiv", true, false);
    DisplayDestinationsService service = new DisplayDestinationsService();
    service.GetFirstTen();
    DownloadDestination download = new DownloadDestination();
    //download.CompressStream(park);
    //download.DecompressFile();

    DestinationsList.GetInstance().Attach(user);
    DestinationsList.GetInstance().State = 3;
    DestinationsList.GetInstance().Notify();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
//Create comments list and remove comment list from destination
//Add relationship between models
//Add comment list to database