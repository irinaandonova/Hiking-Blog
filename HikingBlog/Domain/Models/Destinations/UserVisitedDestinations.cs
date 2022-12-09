using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Domain.Models.Destinations
{
    public class UserVisitedDestinations
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int DestinationId { get; set; }

        public Destination Destination { get; set; }
    }
}
