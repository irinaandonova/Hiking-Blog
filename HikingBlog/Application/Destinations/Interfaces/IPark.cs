using NatureBlog.Application.Destinations.Interfaces;

namespace NatureBlog.Application.Destinations.Interfaces
{
    internal interface IPark : IDestination
    {
        public bool HasPlayground { get; set; }
        public bool IsDogFriendly { get; set; }
    }
}
