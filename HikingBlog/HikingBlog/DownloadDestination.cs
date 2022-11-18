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
        Stream s = File.Create("compressed.dat");

        public void EncryptString()
        {

        }
        public void CompressStream(Destination destination)
        {
            using Stream gzs = new GZipStream(s, CompressionMode.Compress);
            {
                File.Encrypt(destination.Description);
                for (int i = 0; i < destination.Description.Length; i++)
                {
                    byte[] letterBytes = Encoding.ASCII.GetBytes(destination.Description);
                    gzs.Write(letterBytes, 0, letterBytes.Length);
                }
            }
        }

        public void Decompress()
        {
            using Stream stream = File.OpenRead("compressed.dat");
            {
                Stream gzs = new GZipStream(stream, CompressionMode.Decompress);
                string word = "";
                while(gzs != null)
                {
                    int letter = gzs.ReadByte();
                    if (letter == -1)
                        break;
                    word += Convert.ToChar(letter);
                    Console.WriteLine($"{word}");
                }
                File.Decrypt(word);
            }
        }
    }
}







