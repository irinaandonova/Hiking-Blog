using NatureBlog.Database;
using NatureBlog.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NatureBlog.Models
{
    public abstract class Destination
    {
        private Guid Id;

        public Destination(string name, User creator, string description, string imageUrl, string region)
        {
            try
            {
                Id = Guid.NewGuid();
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

        public int? RatingScore { get; set; } = null;

        public Dictionary<string, Comment> Comments { get; set; } = new Dictionary<string, Comment> { };

        public Dictionary<User, int> Ratings { get; set; } = new Dictionary<User, int> { };

        public List<User> Visitors { get; set; } = new List<User> { };
    }
}
