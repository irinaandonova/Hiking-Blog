using MediatR;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Destinations.HikingTrails.Commands.CreateHikingTrail
{
    internal class CreateHikingTrailCommand: IRequest<bool>
    {
        public string Name { get; }

        public User Creator { get; }

        public string Description { get; }

        public string ImageUrl { get; }

        public string Region { get; }

        public bool IsGuarded { get; set; }

        public int Difficulty { get; set; }

        public int Duration { get; set; }

        public int? RatingScore { get; set; } = null;

        public Dictionary<Guid, Comment> Comments { get; set; } = new Dictionary<Guid, Comment> { };

        public Dictionary<User, int> Ratings { get; set; } = new Dictionary<User, int> { };

        public List<User> Visitors { get; set; } = new List<User> { };
    }
}
