using NatureBlog;
using NatureBlog.Extensions;
using NatureBlog.Models;
using NatureBlog.Services;
using System;
using System.IO;

try
{
     
    User user = new User("irina", "irina@", 2);
    Park park = new Park("Layta", user, "Amazing park", "image.com", "Plovdiv", true, false);
    
    DownloadDestination download = new DownloadDestination();
    download.SaveDestination(park);
    download.CompressStream(park);
    
    
    
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
