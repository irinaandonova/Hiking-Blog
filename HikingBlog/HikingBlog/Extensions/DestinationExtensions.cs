using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using HikingBlog.Exceptions;
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
                int ratingScore = destination.RatingScore;
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

                destination.RateDestination(user, ratingValue);

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

        public ChangeDifficulty(this HikiTrail hikiTrail)
        {
            int difficulty;
            try
            {
                bool result = Int32.TryParse(Console.ReadLine(), out difficulty);
                if (!result)
                    throw new FormatException("Incorrect input");
                if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                    SetDifficulty(difficulty);
                else
                    throw new OutOfRangeException("Input should be from 1 to 3");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

