using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NatureBlog.Models.Destinations
{
    public class IDestination<Destination>
    {
        private string RatingScore { get; set; } = "No one has voted yet!";

        private Dictionary<string, Comment> Comments { get; set; } = new Dictionary<string, Comment> { };

        private Dictionary<User, int> Ratings { get; set; } = new Dictionary<User, int> { };

        private List<User> Visitors { get; set; } = new List<User> { };

        public void AddComment(string id, Comment comment) => Comments.Add(id, comment);

        public void RemoveComment(string id) => Comments.Remove(id);

        public void EditComment(string id, string text) => Comments[id].Text = text;

        public bool CompareUser(string id, User creator) => Comments[id].Creator.Equals(creator) ? true : false;

        public List<User> GetVististors() => Visitors;

        public string GetRatingScore() => RatingScore;

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
                RatingScore = ((int)Ratings.Values.Average()).ToString();
               
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

        public void VisitStatus( User visitor)
        {
            int index = Visitors.IndexOf(visitor);

            if (index == -1)
                Visitors.Add(visitor);
            else
                Visitors.RemoveAt(index);
        }
    }
}
