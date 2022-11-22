using System;
using System.Collections.Generic;
using System.Text;

namespace NatureBlog.Models
{
    public class Seaside : Destination
    {
        public Seaside(string name, User creator, string description, string imageUrl, string region, bool isGuarded, bool offersUmbrella) : base(name, creator, description, imageUrl, region)
        {
            IsGuarded = isGuarded;
            OffersUmbrella = offersUmbrella;
        }
        public bool IsGuarded { get; set; }
        public bool OffersUmbrella { get; set; }
        public double UmbrellaPrice { get; set; }
    }
}
