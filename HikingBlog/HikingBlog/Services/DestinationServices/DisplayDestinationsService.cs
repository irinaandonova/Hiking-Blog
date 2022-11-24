using NatureBlog.Database;
using NatureBlog.Exceptions;
using NatureBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NatureBlog.Services.DestinationServices
{
    public class DisplayDestinationsService
    {
        public List<Destination> AllDestinations = DestinationsList.GetInstance().AllDestinations;

        public void GetFirstTen()
        {
            try
            {
                var condition = from destination in AllDestinations orderby destination.Visitors.Count select destination;

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

        public Destination GetDestination(string name)
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

        public List<Seaside> GetAllSeaside()
        {
            try
            {
                List<Seaside> destinations = AllDestinations.Where(x => x is Seaside).Select(s => s as Seaside).ToList();
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

        public List<HikingTrail> GetAllHikingTrails()
        {
            try
            {
                List<HikingTrail> destinations = AllDestinations.Where(x => x is HikingTrail).Select(s => s as HikingTrail).ToList();
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

        public List<Park> GetAllParks()
        {
            try
            {
                List<Park> destinations = AllDestinations.Where(x => x is Park).Select(s => s as Park).ToList();
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
                List<HikingTrail> hikingTrails = GetAllHikingTrails();
                if (hikingTrails.Count() < 0)
                    throw new DestinationNotFoundException("There are no hiking elements that fullfil the condition in the collection");

                foreach (HikingTrail hikingTrail in hikingTrails)
                {
                    ShowInfo(hikingTrail);
                }
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine("They are no hiking trails with that leve of difficulty");
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
                List<Seaside> seasides = GetAllSeaside();
                seasides = seasides.Where(x => x.IsGuarded).ToList();
                if (seasides.Count() < 0)
                    throw new DestinationNotFoundException("There are no such elements in the collection");

                foreach (Seaside seaside in seasides)
                {
                    ShowInfo(seaside);
                }
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine($"There are no destination in that fullfils this conditions");
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
                List<Park> parks = GetAllParks();
                parks = parks.Where(x => x.HasPlayground == hasPlayground && x.IsDogFriendly == isDogFriendly).ToList();

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

        public List<Destination> SearchDestination(string searchWord)
        {
            try
            {
                List<Destination> destinations = AllDestinations.Where(d => d.Name.Contains(searchWord)).ToList();
                if (destinations.Count() < 0)
                    throw new DestinationNotFoundException("No elements that fullfil this condition!");

                return destinations;
            }
            catch (DestinationNotFoundException)
            {
                Console.WriteLine($"The are no destinations that contain '{searchWord}' in their name!");
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
                    throw new ArgumentOutOfRangeException("Invalid condition!");

                if (AllDestinations.Count() < 0)
                    throw new DestinationNotFoundException("No destinations in the collection!");
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
           
        }

        public void ShowFullInformation(HikingTrail hikingTrail)
        {
            Console.WriteLine(hikingTrail.Name);
            try
            {
                int? ratingScore = hikingTrail.RatingScore;
                if (ratingScore is null)
                    Console.WriteLine("No one has voted yet");
                Console.WriteLine($"{hikingTrail.Name} rating is {ratingScore}");
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
                Console.WriteLine(hikingTrail.Region);
            }

            Console.WriteLine($"Difficulty: {hikingTrail.Difficulty}");
            Console.WriteLine($"Hiking duration {hikingTrail.HikingDuration}");

            foreach (KeyValuePair<string, Comment> comment in hikingTrail.Comments)
            {
                Console.WriteLine(comment);
                //Console.WriteLine(comment.Date.ToString());
                //Console.WriteLine(comment.Creator.Username);
                //Console.WriteLine(comment.Text);
            }
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

        public void ShowUmbrellaPrices(Seaside seaside)
        {
            if (seaside.OffersUmbrella)
                Console.WriteLine($"An umbrella could be rented for {seaside.UmbrellaPrice:C}");
            else
                Console.WriteLine(" destination doesn't offer umbrellas");
        }
    }
}
