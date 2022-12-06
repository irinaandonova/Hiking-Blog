using NatureBlog.Domain.Models;

namespace NatureBlog.Domain.Models
{
    public class Region
    {
        public Guid Id;

        public string Name { get; set; }

        public string Cordinates { get; set; }

        public ICollection<Destination> Destinations { get; set; }
    }
}
