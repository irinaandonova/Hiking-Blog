using NatureBlog.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NatureBlog.Domain.Models
{
    public class Region
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Cordinates { get; set; }

        public ICollection<Destination> Destinations { get; set; }
    }
}
