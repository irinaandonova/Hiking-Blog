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
        }

        public void CompressStream(Destination destination)
        {
            try
            {
                SaveDestination(destination);
                using FileStream originalFileStream = File.Open("destination.txt", FileMode.Open);
                using FileStream compressedFileStream = File.Create("compressed.gz");
                using var compressor = new GZipStream(compressedFileStream, CompressionMode.Compress, false);
                originalFileStream.CopyTo(compressedFileStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void DecompressFile()
        {
            using FileStream compressedFileStream = File.Open("destination.txt", FileMode.Open);
            using FileStream outputFileStream = File.Create("decompressed.txt");
            using var decompressor = new GZipStream(compressedFileStream, CompressionMode.Decompress);
            decompressor.CopyTo(outputFileStream);
        }

    }
}













