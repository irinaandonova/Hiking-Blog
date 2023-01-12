using System.ComponentModel.DataAnnotations;

namespace NatureBlog.Application.Dto.Destination.HikingTrail
{
    public class HikingTrailPostDto
    {
        [Required]
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        public int CreatorId { get; set; }

        [Required]
        [MaxLength(960)]
        [MinLength(2)]
        public string Description { get; set; }

        [Required]
        [MaxLength(200)]
        [MinLength(5)]
        public string ImageUrl { get; set; }

        [Required]
        public int RegionId { get; set; }
        [Required]
        public int Difficulty { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
