using NatureBlog.Application.Destinations.Interfaces;

namespace NatureBlog.Application.Destinations.Interfaces
{
    internal interface ISeaside : IDestination
    {
        bool IsGuarded { get; set; }

        bool OffersUmbrella { get; set; }

        double UmbrellaPrice { get; set; }
    }
}
