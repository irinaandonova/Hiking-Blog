using NatureBlog.Application.Destinations.Interfaces;

namespace Application.Destinations.Interfaces
{
    internal interface IHikingTrail : IDestination
    {
        public int Difficulty { get; set; }

        public int HikingDuration { get; set; }
    }
}
