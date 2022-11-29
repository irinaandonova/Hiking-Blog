using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NatureBlog.Application.Destinations.Interfaces
{
    internal interface ISeaside: IDestination
    {
        public bool IsGuarded { get;set; }

        public bool OffersUmbrella { get; set; }
        public double UmbrellaPrice { get; set; }
    }
}
