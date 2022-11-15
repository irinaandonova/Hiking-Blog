using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HikingBlog.Models;

namespace HikingBlog.Extensions
{
    internal static class DestinationExtensions
    {
        public static void ShowInfo(this Destination destination)
        {
            Console.WriteLine(destination.Name);
            try
            {
                int ratingScore = destination.CalcRatingScore();
                Console.WriteLine($"{destination.Name} rating is {ratingScore}");
            }
            catch (DivideByZeroException)
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

        public static void VisitStatus(this Destination destination, User visitor)
        {
            int index = destination.Visitors.IndexOf(visitor);

            if (index == -1)
                destination.Visitors.Add(visitor);
            else
                destination.Visitors.RemoveAt(index);
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
    }
}

