using NatureBlog.Database;
using NatureBlog.Exceptions;
using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NatureBlog.Services.DestinationServices
{
    internal class ModifyDestinationsService
    {
        public List<Destination> AllDestinations = DestinationsList.GetInstance().AllDestinations;

        public void RemoveDestination(string name)
        {
            try
            {
                Destination destination = AllDestinations.SingleOrDefault(x => x.Name == name);
                if (destination == null)
                    throw new DestinationNotFoundException();
                AllDestinations.Remove(destination);
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine("No such destination");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("More than one destination with that name!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddUmbrellaPrices(Seaside seaside, double umbrellaPrice)
        {
            if (!seaside.OffersUmbrella)
                seaside.OffersUmbrella = true;
            seaside.UmbrellaPrice = umbrellaPrice;
        }

        public void RateDestination(Destination destination, int ratingValue, User user)
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

        public void ChangeDifficulty(HikingTrail hikingTrail)
        {
            int difficulty;
            try
            {
                bool result = int.TryParse(Console.ReadLine(), out difficulty);
                if (!result)
                    throw new FormatException("Incorrect input!");
                if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                    hikingTrail.Difficulty = difficulty;
                else
                    throw new OutOfRangeException("Input should be from 1 to 3!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /*
       

        public void RateDestination(User user, int rating)
        {
            try
            {
                
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

        public void VisitStatus(Destination User visitor)
        {
            int index = Visitors.IndexOf(visitor);

            if (index == -1)
                Visitors.Add(visitor);
            else
                Visitors.RemoveAt(index);
        }
        */
    }
}
