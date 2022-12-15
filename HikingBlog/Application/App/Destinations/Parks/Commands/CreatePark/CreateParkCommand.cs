﻿using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Parks.Commands.CreatePark
{
    public class CreateParkCommand : IRequest<int?>
    {
        public string Name { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Region Region { get; set; }

        public int? RatingScore { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<User> Visitors { get; set; } 

        public bool HasPlayground { get; set; }

        public bool IsDogFriendly { get; set; }
    }
}
