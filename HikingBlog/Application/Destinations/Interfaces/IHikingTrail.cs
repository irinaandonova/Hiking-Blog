using NatureBlog.Application.Destinations.Interfaces;

namespace NatureBlog.Application.Destinations.Interfaces
{
    internal interface IHikingTrail : IDestination
    {
        public int Difficulty { get; set; }

        public int HikingDuration { get; set; }
    }
}
