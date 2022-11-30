using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Destinations.Interfaces
{
    public interface IDestination
    {
        public string Name { get; }

        public User Creator { get; }

        public int Difficulty { get; set; }

        public string Description { get; }

        public string ImageUrl { get; }

        public string Region { get; }

        public int? RatingScore { get; set; }

        public Dictionary<Guid, Comment> Comments { get; set; } 

        public Dictionary<User, int> Ratings { get; set; } 

        public List<User> Visitors { get; set; }
    }
}
