using NatureBlog.Exceptions;
using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NatureBlog.Services
{
    public class WebAPI
    {
        public List<Destination> AllDestinations = new List<Destination> { };

        public void GetFirstTen()
        {
            try
            {
                var condition = from destination in AllDestinations orderby destination.GetVististors().Count select destination;

                foreach (Destination destination in condition.Take(10))
                {
                    ShowInfo(destination);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void AddDestination(Destination destination)
        {
            try
            {
                AllDestinations.Add(destination);
                if (!AllDestinations.Contains(destination))
                    throw new NotImplementedException("Element not added successfully");
            }
            catch (NotImplementedException)
            {
                Console.WriteLine("Creation of destination failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

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

        public Destination? GetDestination(string name)
        {
            try
            {
                Destination destination = AllDestinations.SingleOrDefault(x => x.Name == name);
                if (destination is null)
                    throw new DestinationNotFoundException();
                return destination;
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine($"No {name} destination in the data base");
                return null;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("More than one destination with that name!");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Seaside> GetAllSeaside()
        {
            try
            {
                var destinations = AllDestinations.Where(x => x is Seaside).Select(s => s as Seaside);
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");
                return destinations;
            }

            catch (DestinationNotFoundException)
            {
                Console.WriteLine("There are no destinations yet");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<HikingTrail> GetAllHikingTrails()
        {
            try
            {
                var destinations = AllDestinations.Where(x => x is HikingTrail).Select(s => s as HikingTrail);
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");
                return destinations;
            }

            catch (DestinationNotFoundException)
            {
                Console.WriteLine("There are no destinations yet");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public IEnumerable<Park> GetAllParks()
        {
            try
            {
                var destinations = AllDestinations.Where(x => x is Park).Select(s => s as Park);
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                return destinations;
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine("There are no destinations yet");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void FilterHikingTrail(int difficulty)
        {
            try
            {
                IEnumerable<HikingTrail> hikingTrails = GetAllHikingTrails();
                if (hikingTrails.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                foreach (HikingTrail hikingTrail in hikingTrails)
                {
                    ShowInfo(hikingTrail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FilterSeaside(bool isGuarded)
        {
            try
            {
                IEnumerable<Seaside> seasides = GetAllSeaside();
                seasides = seasides.Where(x => x.IsGuarded);
                if (seasides.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements in the collection");

                foreach (Seaside seaside in seasides)
                {
                    ShowInfo(seaside);
                }
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine($"There are no destination in that fullfils  conditions");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FilterPark(bool hasPlayground, bool isDogFriendly)
        {
            try
            {
                IEnumerable<Park> parks = GetAllParks();
                parks = parks.Where(x => x.HasPlayground == hasPlayground && x.IsDogFriendly == isDogFriendly);

                if (parks.Count() < 0)
                    throw new DestinationNotFoundException("There are no elements on the collection");

                foreach (Park park in parks)
                {
                    ShowInfo(park);
                }
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine($"The are no destinations in that fullfils  conditions");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void FilterByRegion(string Region)
        {
            try
            {
                List<Destination> destinations = AllDestinations.FindAll(x => x.Region == Region);
                if (destinations.Count < 0)
                {
                    foreach (Destination destination in destinations)
                    {
                        ShowInfo(destination);
                    }
                }
                else
                    throw new DestinationNotFoundException("The are no elements in the collection");
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine($"The are no destination in the {Region} region");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public IEnumerable<Destination> SearchDestination(string searchWord)
        {
            try
            {
                IEnumerable<Destination> destinations = AllDestinations.Where(d => d.Name.Contains(searchWord));
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("No elements that fullfil this condition!");

                return destinations;
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine($"The are no destinations that contain {searchWord} in their name!");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void SortDestinations(string condition)
        {
            try
            {
                if (condition == "alphabetical")
                    AllDestinations.Sort((a, b) => a.Name.CompareTo(b.Name));
                else if (condition == "reverse alphabetical")
                    AllDestinations.Sort((b, a) => b.Name.CompareTo(a.Name));
                else if (condition == "accending difficulty")
                    AllDestinations.Sort((a, b) => b.Difficulty - a.Difficulty);
                else if (condition == "descending difficulty")
                    AllDestinations.Sort((a, b) => a.Difficulty - b.Difficulty);
                else
                    throw new ArgumentOutOfRangeException("Invalid condition");

                foreach (var destination in AllDestinations)
                    ShowInfo(destination);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void ShowInfo(Destination destination)
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

        public void ShowFullInformation(HikingTrail hikingTrail)
        {
            ShowInfo(hikingTrail);

            Console.WriteLine($"Difficulty: {hikingTrail.GetDifficulty()}");
            Console.WriteLine($"Hiking duration {hikingTrail.HikingDuration}");
        }

        public void ShowFullInformation(Seaside seaside)
        {
            ShowInfo(seaside);

            if (seaside.IsGuarded)
                Console.WriteLine("The beach is guarded by a lifeguard");
            else
                Console.WriteLine("The beach isn't guarded by a lifeguarld.");
        }

        public void ShowFullInformation(Park park)
        {
            ShowInfo(park);

            Console.WriteLine($"The park has a children's playground.");
            Console.WriteLine($"The park is dog friendly");
        }

        public void AddUmbrellaPrices(Seaside seaside, double umbrellaPrice)
        {
            if (!seaside.OffersUmbrella)
                seaside.OffersUmbrella = true;
            seaside.UmbrellaPrice = umbrellaPrice;
        }

        public void ShowUmbrellaPrices(Seaside seaside)
        {
            if (seaside.OffersUmbrella)
                Console.WriteLine($"An umbrella could be rented for {seaside.UmbrellaPrice:C}");
            else
                Console.WriteLine(" destination doesn't offer umbrellas");
        }

        public void RateDestination(Destination destination, int ratingValue, User user)
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

        public void ChangeDifficulty(HikingTrail hikingTrail)
        {
            int difficulty;
            try
            {
                bool result = Int32.TryParse(Console.ReadLine(), out difficulty);
                if (!result)
                    throw new FormatException("Incorrect input");
                if (difficulty == 1 || difficulty == 2 || difficulty == 3)
                    hikingTrail.SetDifficulty(difficulty);
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
