using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NatureBlog.Models
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
                Ratings = new Dictionary<User, int> { };
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

        public string Name { get; }

        public User Creator { get; }

        public int Difficulty { get; set; }

        public string Description { get; }

        public string ImageUrl { get; }

        public string Region { get; }

        public int RatingScore { get; set; }

        private Dictionary<string, Comment> Comments { get; set; }

        private Dictionary<User, int> Ratings { get; set; }

        private List<User> Visitors { get; set; }

        public void AddComment(string id, Comment comment) => Comments.Add(id, comment);

        public void RemoveComment(string id) => Comments.Remove(id);

        public void EditComment(string id, string text) => Comments[id].Text = text;

        public bool CompareUser(string id, User creator) => Comments[id].Creator.Equals(creator) ? true : false;


        public List<User> GetVististors() => Visitors;
        public void ShowComments()
        {
            foreach (KeyValuePair<string, Comment> comment in Comments)
                comment.Value.ShowComment();
        }

        public void RateDestination(User user, int rating)
        {
            try
            {
                if (Ratings.ContainsKey(user))
                    Ratings[user] = rating;

                else
                    Ratings.Add(user, rating);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void CalcRatingScore(Destination destination)
        {
            try
            {
                RatingScore = (int)Ratings.Values.Average();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("The are no rating yet");
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

        public void VisitStatus(Destination destination, User visitor)
        {
            int index = destination.Visitors.IndexOf(visitor);

            if (index == -1)
                destination.Visitors.Add(visitor);
            else
                destination.Visitors.RemoveAt(index);
        }

        
    }
}
