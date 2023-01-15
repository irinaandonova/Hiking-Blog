namespace NatureBlog.Application.Dto.Destination.Park
{
    public class ParkPutDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int CreatorId { get; set; }

        public int RegionId { get; set; }

        public bool HasPlaygroung { get; set; }

        public bool IsDogFriendly { get; set; }

        public int UserId { get; set; }
    }
}
