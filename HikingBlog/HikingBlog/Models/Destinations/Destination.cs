using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class Destination
    {
        public Dictionary<string, Comment> Comments = new Dictionary<string, Comment> { };
        public Destination(string name, User creator, string description, string imageUrl, string region)
        {
            Name = name;
            Creator = creator;
            Description = description;
            ImageUrl = imageUrl;
            Region = region;
        }

        public string Name { get; set; }
        public User Creator { get; set; }
        public int Difficulty { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Region { get; set; }

        public void RateDestination(int ratingValue, User user)
        {
            try
            {
             Rating rating = new Rating(ratingValue, user);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            catch(Exception ex)
            {
                Console.WriteLine(Exception(ex.Message));
            }
        }
    }
}
