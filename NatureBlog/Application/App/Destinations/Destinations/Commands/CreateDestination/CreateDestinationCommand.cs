using MediatR;

namespace NatureBlog.Application.App.Destinations.Destinations.Commands.CreateDestination
{
    public class CreateDestinationCommand : IRequest<int?>
    {
        public string Name { get; set; }

        public int CreatorId { get; set; }

        public int RegionId { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? Difficulty { get; set; }

        public int? Duration { get; set; }

        public bool? HasUmbrella { get; set; }

        public bool? IsGuarded { get; set; }

        public bool? HasPlayground { get; set; }

        public bool? IsDogFriendly { get; set; }
    }
}
