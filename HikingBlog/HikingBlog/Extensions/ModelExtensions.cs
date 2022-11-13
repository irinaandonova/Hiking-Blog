using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using HikingBlog.Models;

namespace HikingBlog.Extensions
{
    internal static class ModelExtensions
    {
        public static void CreateComment(this Destination destination, User creator, string text)
        {
            Comment comment = new Comment(creator, text);
            string id = comment.Id;
            destination.Comments.Add(id, comment);
        }

        public static void ShowComments(this Destination destination)
        {
            foreach (KeyValuePair<string, Comment> comment in destination.Comments)
            {
                Console.WriteLine(comment.Value.Text);
            }
        }

        public static void AddUmbrellaPrices(this Seaside seaside, double umbrellaPrice)
        {
            if (!seaside.OffersUmbrella)
                seaside.OffersUmbrella = true;
            seaside.UmbrellaPrice = umbrellaPrice;
        }

        public static void ShowUmbrellaPrices(this Seaside seaside)
        {
            if (seaside.OffersUmbrella)
                Console.WriteLine($"An umbrella could be rented for {seaside.UmbrellaPrice:C}");
            else
                Console.WriteLine("This destination doesn't offer umbrellas");
        }

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

        public static int CalcRatingScore(this Destination destination)
        {
            int ratingScore = 0;
            foreach (KeyValuePair<User, int> ratingValue in destination.Ratings)
            {
                ratingScore += ratingValue.Value;
            }
            try
            {
                return ratingScore / destination.Ratings.Count;
            }
            catch (DivideByZeroException)
            {
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ShowInfo(this Destination destination)
        {
            Console.WriteLine(destination.Name);

            int ratingScore = destination.CalcRatingScore();
            try
            {
                    Console.WriteLine($"{destination.Name} rating is {ratingScore}");
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("No one has voted yet");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine(destination.Description);
                Console.WriteLine(destination.Region);
            }
        }

        public static void ShowFullInformation(this HikingTrail hikingTrail)
        {
            ShowInfo(hikingTrail);

            Console.WriteLine($"Difficulty: {hikingTrail.Difficulty}");
            Console.WriteLine($"Hiking duration {hikingTrail.HikingDuration}");
        }

        public static void ShowFullInformation(this Seaside seaside)
        {
            ShowInfo(seaside);

            if (seaside.IsGuarded)
                Console.WriteLine("The beach is guarded by a lifeguard");
            else
                Console.WriteLine("The beach isn't guarded by a lifeguarld.");
        }

        public static void ShowFullInformation(this Park park)
        {
            ShowInfo(park);

            Console.WriteLine($"The park has a children's playground.");
            Console.WriteLine($"The park is dog friendly");
        }
    }
}

