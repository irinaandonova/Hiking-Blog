using MediatR;

namespace NatureBlog.Application.Destinations.Seasides.Commands.AddUmbrellaPrices
{
    public class AddUmbrellaPricesCommand : IRequest<bool>
    {
        public Guid seasideId { get; }

        public double umbrellaPrice { get; set; }
    }
}
