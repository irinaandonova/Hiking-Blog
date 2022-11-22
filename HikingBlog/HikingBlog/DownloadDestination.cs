using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NatureBlog.Models;
using System.Security.Cryptography;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace NatureBlog
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

        private static void CreateFileToCompress(string line) => File.WriteAllText("text.txt", line);

        public void CompressStream(Destination destination)
        {
            try
            {
                string line = "Description: " + destination.Description;
                CreateFileToCompress(line);
                using (FileStream originalFileStream = File.Open("text.txt", FileMode.Open))
                using (FileStream compressedFileStream = File.Create("compressed.txt"))
                using (var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress))
                {
                    originalFileStream.CopyTo(compressor);
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
                        for (byte i = 0; i < 100; i++)
                        gs.WriteByte(i);
                    }
                }
            }
        }

    }

}













