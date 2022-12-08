using MediatR;
using NatureBlog.Domain.Models;

namespace NatuteBlog.Application.Regions
{
    public class CreateRegionCommand : IRequest<bool>
    {
        public string Name { get; set; }

        public string Cordinates { get; set; }

        public ICollection<Destination> Destinations { get; set; }

    }
}
