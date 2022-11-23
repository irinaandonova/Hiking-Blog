using NatureBlog.Models.Destinations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NatureBlog.Models
{
    public abstract class Destination: IDestination<Destination>
    {
        public Destination(string name, User creator, string description, string imageUrl, string region)
        {
            try
            {
                Name = name;
                Creator = creator;
                Description = description;
                ImageUrl = imageUrl;
                Region = region;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("All fields must be filled!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        public string Name { get; }

        public User Creator { get; }

        public int Difficulty { get; set; }

        public string Description { get; }

        public string ImageUrl { get; }

        public string Region { get; }


    }
}
