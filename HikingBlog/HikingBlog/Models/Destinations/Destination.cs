﻿using NatureBlog.Exceptions;
using NatureBlog.Models.Destinations;
using NatureBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NatureBlog.Models
{
    public abstract class Destination : IDestination<Destination>
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
                AllDestinations.Add(this);
                if (!AllDestinations.Contains(this))
                    throw new DestinationNotFoundException("The destination wasn't added successfully to database!");
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

        public List<Destination> AllDestinations = DestinationsList.GetInstance().AllDestinations;

    }
}
