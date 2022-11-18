using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HikingBlog.Models;

namespace HikingBlog
{
    internal class DownloadDestination
    {
        Stream stream = File.Create("destination.txt");

        public void SaveDestination(Destination destination)
        {
            using StreamWriter sw = new StreamWriter(stream);

                sw.WriteLine($"Destination name: {destination.Name}");
                sw.WriteLine($"Description: {destination.Description}");
                sw.WriteLine($"Region {destination.Region}");
                sw.WriteLine($"Rating Score: {destination.RatingScore}");
        }
        /*
        Stream s = File.Create("compressed.dat");
        
        public void CompressStream(Destination destination)
        {
            string line = "Description: " + destination.Description;
            using Stream gzs = new GZipStream(s, CompressionMode.Compress);
            {
                    File.Encrypt(line);
                    byte[] letterBytes = Encoding.ASCII.GetBytes(line);
                    gzs.Write(letterBytes, 0, letterBytes.Length);
            }
        }

        public void Decompress()
        {
            using Stream stream = File.OpenRead("compressed.dat");
            {
                Stream gzs = new GZipStream(stream, CompressionMode.Decompress);
                string word = "";
                while (gzs != null)
                {
                    int letter = gzs.ReadByte();

                    if (letter == -1)
                        break;
                    word += Convert.ToChar(letter);
                }
                File.Decrypt(word);
                Console.WriteLine($"{word}");

            }
        }

        */
    }
}







