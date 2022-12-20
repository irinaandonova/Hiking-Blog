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

        bool HasPlaygroung { get; set; }

        bool IsDogFriendly { get; set; }
    }
}
