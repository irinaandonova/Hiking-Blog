using NatureBlog.Domain.Models;

namespace NatureBlog.Presenatation.Dto.Destination
{
    public class HikingTrailGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int RegionId { get; set; }

        public int Difficulty { get; set; }

        public int Duration { get; set; }
    }
}
