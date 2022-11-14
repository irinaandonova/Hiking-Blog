﻿using HikingBlog.Extensions;
using HikingBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HikingBlog.Services
{
    public class WebAPI
    {
        public List<Destination> AllDestinations = new List<Destination> { };

        public void GetFirstTen()
        {
            var condition = from destination in AllDestinations orderby destination.Visitors.Count select destination;

            foreach(Destination destination in condition.Take(10))
            {
                destination.ShowInfo();
            }
        }

        public void AddDestination(Destination destination)
        {
            AllDestinations.Add(destination);
        }

        public void RemoveDestination(string name)
        {
            try
            {
                Destination destination = AllDestinations.Single(x => x.Name == name);
                AllDestinations.Remove(destination);
            }
            catch(ArgumentNullException)
            {
                Console.WriteLine("No such element");
            }
            catch(InvalidOperationException)
            {
                Console.WriteLine("More than one destination with that name!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Destination? GetDestination(string name)
        {
            try
            {
                return AllDestinations.Single(x => x.Name == name);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("No such element");
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
        /*
        public List<Seaside> GetAllSeaside()
        {
            return (List<Seaside>)AllDestinations.Where(x => x.GetType() == typeof(Seaside));
        }
        */
       public void FilterHikingTrail(int difficulty)
        {
            try
            {
                List<HikingTrail> hikingTrails = (List<HikingTrail>)AllDestinations.Where(x => x.Difficulty == difficulty);
                
                foreach(HikingTrail hikingTrail in hikingTrails)
                    {
                        hikingTrail.ShowInfo();
                    }
                
            }
            catch(CustomException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
