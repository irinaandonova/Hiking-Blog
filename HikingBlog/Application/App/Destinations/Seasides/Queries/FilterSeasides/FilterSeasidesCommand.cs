using MediatR;
using NatureBlog.Domain.Models;

namespace Application.App.Destinations.Seasides.Queries.FilterSeasides
{
    public class FilterSeasidesCommand : IRequest<List<Seaside>>
    {
        public bool IsGuarded;

        public bool OffersUmbrellas;
    }
}
