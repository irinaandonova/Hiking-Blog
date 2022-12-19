using MediatR;
using NatureBlog.Domain.Models;

namespace NatuteBlog.Application.Regions
{
    public class CreateRegionCommand : IRequest<Region>
    {
        public string Name { get; set; }

        public string Cordinates { get; set; }

    }
}
