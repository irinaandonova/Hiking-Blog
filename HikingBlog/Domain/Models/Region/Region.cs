using NatureBlog.Domain.Models;

namespace NatureBlog.Domain.Models
{
    public class Region
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cordinates { get; set; }

        public ICollection<Destination> Destinations { get; set; } = null;
    }
}
