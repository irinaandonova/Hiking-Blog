namespace NatureBlog.Domain.Models
{
    public class Seaside : Destination
    {
        public bool IsGuarded { get; set; }

        public bool OffersUmbrella { get; set; }

        public double UmbrellaPrice { get; set; }
    }
}
