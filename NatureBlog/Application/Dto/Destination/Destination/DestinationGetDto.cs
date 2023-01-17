using NatureBlog.Application.Dto.User;

namespace NatureBlog.Application.Dto.Destination.Destination
{
    public class DestinationGetDto
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        public string Type { get; set; }

        public int? HikingDuration { get; set; }

        public int? Difficulty { get; set; }

        public bool? IsGuarded { get; set; }

        public bool? HasUmbrella { get; set; }

        public bool? HasPlayground { get; set; }

        public bool? IsDogFriendly { get; set; }

        public decimal RatingScore { get; set; }

        public ICollection<UserGetDto> Visitors { get; set; }
    }
}
