using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog.Models
{
    public class Destination
    {
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
        public Dictionary<string, Comment> Comments = new Dictionary<string, Comment> { };
        public Dictionary<User, int> Ratings = new Dictionary<User, int> { };
        public void RateDestination(int ratingValue, User user)
        {
            try
            {
                if (ratingValue <= 0 || ratingValue > 5)
                    throw new ArgumentOutOfRangeException("Rating value should be between 1 and 2");
                if (user == null)
                    throw new ArgumentNullException("User field is missing!");
                if (Ratings.ContainsKey(user))
                    Ratings[user] = ratingValue;
                else
                    Ratings.Add(user, ratingValue);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.ParamName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       private int CalcRatingScore()
        {
            int ratingScore = 0;
            foreach (KeyValuePair<User, int> ratingValue in Ratings)
            {
                ratingScore += ratingValue.Value;
            }
            try
            {
                return ratingScore / Ratings.Count;
            }
            catch(DivideByZeroException)
            {
                return 0;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    public void ShowInfo()
        {
            Console.WriteLine(Name);
            
            int ratingScore = CalcRatingScore();
            try
            {
                if (ratingScore == 0)
                    Console.WriteLine("No one has voted yet");
                else
                    Console.WriteLine($"{Name} rating is {ratingScore}");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(Description);
                Console.WriteLine(Region);
            }
        }
    }
}
