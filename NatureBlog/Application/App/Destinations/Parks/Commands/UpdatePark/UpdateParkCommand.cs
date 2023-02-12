using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Destinations.Parks.Commands.UpdatePark 
{
    public class UpdateParkCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        public bool HasPlayground { get; set; }

        public bool IsDogFriendly { get; set; }
    }
}
