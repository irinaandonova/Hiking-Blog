using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikingBlog.Models;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;

namespace HikingBlog
{
    internal class DownloadDestination
    {
        public void SaveDestination(Destination destination)
        {
            Stream stream = System.IO.File.Create("destination.txt");
            using StreamWriter sw = new StreamWriter(stream);
            sw.WriteLine($"Destination name: {destination.Name}");
            sw.WriteLine($"Description: {destination.Description}");
            sw.WriteLine($"Region {destination.Region}");
            sw.WriteLine($"Rating Score: {destination.RatingScore}");
            sw.Dispose();
        }

        public void CompressStream(Destination destination)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter("text.txt"))
                {
                    sw.WriteLine(destination.Description);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                using (Aes aes = Aes.Create())
                {

                    using (FileStream fs = new FileStream("text.txt", FileMode.OpenOrCreate))
                    {
                        using (CryptoStream cs = new CryptoStream(fs, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            using (FileStream fs = new FileStream("text.txt", FileMode.OpenOrCreate))
            {
                using (FileStream cs = new FileStream("compressed.txt", FileMode.OpenOrCreate))
                {
                    using (GZipStream gs = new GZipStream(cs, CompressionMode.Compress))
                    {
                        fs.CopyTo(cs);
                    }
                }
            }
        }

    }

}













