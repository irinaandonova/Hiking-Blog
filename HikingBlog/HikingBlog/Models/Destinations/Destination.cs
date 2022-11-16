using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikingBlog.Models
{
    public class Destination
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
                new Dictionary<User, int> { };
                Comments = new Dictionary<string, Comment> { };
                Visitors = new List<User> { };
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

        public string Name { get; set; }

        public User Creator { get; set; }

        public int Difficulty { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Region { get; set; }

        private Dictionary<string, Comment> Comments { get; set; }

        private Dictionary<User, int> Ratings { get; set; }

        private List<User> Visitors { get; set; }

        public void AddComment(string id, Comment comment) => Comments.Add(id, comment);

        public void RemoveComment(string id) => Comments.Remove(id);

        public void EditComment(string id, string text) => Comments[id].Text = text;

        public bool CompareUser(string id, User creator) => Comments[id].Creator.Equals(creator) ? true : false;

        
        
        public static void RateDestination(this Destination destination, int ratingValue, User user)
        {
            try
            {
                if (ratingValue <= 0 || ratingValue > 5)
                    throw new ArgumentOutOfRangeException("Rating value should be between 1 and 2");
                if (user == null)
                    throw new ArgumentNullException("User field is missing!");
                if (destination.Ratings.ContainsKey(user))
                    destination.Ratings[user] = ratingValue;
                else
                    destination.Ratings.Add(user, ratingValue);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int CalcRatingScore(this Destination destination)
        {
            int ratingScore;
            try
            {
                ratingScore = (int)destination.Ratings.Values.Average();
                return ratingScore;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("The are no rating yet");
                return 0;
            }
            catch (InvalidOperationException)
            {
                throw new Exception("The are no rating yet");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void VisitStatus(this Destination destination, User visitor)
        {
            int index = destination.Visitors.IndexOf(visitor);

            if (index == -1)
                destination.Visitors.Add(visitor);
            else
                destination.Visitors.RemoveAt(index);
        }
    }
}
