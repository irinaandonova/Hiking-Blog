namespace NatureBlog.Application.Dto.Destination.Seaside
{
    public class SeasideGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        bool OffersUmbrella { get; set; }

        bool IsGuarded { get; set; }
    }
}
