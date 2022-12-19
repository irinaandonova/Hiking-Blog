using MediatR;

namespace NatureBlog.Application.Destinations.Seasides.Commands.AddUmbrellaPrices
{
    public class AddUmbrellaPricesCommand : IRequest<bool>
    {
        public int seasideId { get; set; }

        public double umbrellaPrice { get; set; }
    }
}
