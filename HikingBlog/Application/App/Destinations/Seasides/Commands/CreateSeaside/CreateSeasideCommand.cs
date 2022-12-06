﻿using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Destinations.Seasides.Commands.CreateSeaside
{
    public class CreateSeasideCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public Guid CreatorId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Region Region { get; set;  }

        public bool IsGuarded { get; set; }

        public bool OffersUmbrella { get; set; }

        public double UmbrellaPrice { get; set; }

        public int? RatingScore { get; set; } = null;

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public ICollection<User> Visitors { get; set; } = new List<User> { };
    }
}
