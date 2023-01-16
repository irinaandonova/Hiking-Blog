namespace NatureBlog.Application.Dto.Destination.Park
{
    public class ParkGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
        
        public int CreatorId { get; set; }

        public int RegionId { get; set; }

        public bool HasPlaygroung { get; set; }

        public bool IsDogFriendly { get; set; }

        public decimal RatingScore { get; set; }
    }
}
