using NatureBlog.Domain.Models;

namespace NatureBlog.Application.Dto.Destination.Destination
{
    public class DestinationRatingGetDto
    {
        public List<Rating> Ratings { get; set; }

        public decimal Rating { get; set; }
    }
}
