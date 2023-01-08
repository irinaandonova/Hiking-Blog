using MediatR;
using NatureBlog.Domain.Models;

namespace NatureBlog.Application.App.Regions.Commands.CreateRegion
{
    public class CreateRegionCommand : IRequest<Region>
    {
        public string Name { get; set; }

        public string Cordinates { get; set; }

    }
}
