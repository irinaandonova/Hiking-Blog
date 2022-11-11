using System;
using System.Collections.Generic;
using System.Text;

namespace HikingBlog
{
    public class Seaside: Destination
    {
        private bool IsGuarded;
        private bool OffersUmbrella;
        private double UmbrellaPrice;
        
        public Seaside(string name, User creator, string description, string imageUrl, string region, bool isGuarded, bool offersUmbrella) : base(name, creator, description, imageUrl, region)
        {
            IsGuarded = isGuarded;
            OffersUmbrella = offersUmbrella;
        }
        public void AddUmbrellaPrices(double umbrellaPrice)
        {
            if (!OffersUmbrella)
                OffersUmbrella = true;
            UmbrellaPrice = umbrellaPrice;            
        }
    }
}
