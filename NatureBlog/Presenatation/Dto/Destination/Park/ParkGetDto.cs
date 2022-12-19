using NatureBlog.Domain.Models;

namespace Presenatation.Dto.Destination.Park
{
    public class ParkGetDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        
        public Region Region { get; set; }

        bool HasPlaygroung { get; set; }

        bool IsDogFriendly { get; set; }
    }
}
