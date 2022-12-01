using MediatR;

namespace NatureBlog.Application.Destinations.Seasides.Commands.AddUmbrellaPrices
{
    public class AddUmbrellaPricesCommand : IRequest<bool>
    {
        public Guid seasideId;

        public double umbrellaPrice;
    }
}
