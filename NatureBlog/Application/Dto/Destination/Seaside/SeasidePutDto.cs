namespace NatureBlog.Application.Dto.Destination.Seaside
{
    public class SeasidePutDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        public bool OffersUmbrella { get; set; }

        public bool IsGuarded { get; set; }
    }
}
