using MediatR;
using NatureBlog.Domain.Models;

namespace Application.Destinations.Seasides.Queries.FilterSeaside
{
    public class FilterSeasidesCommand : IRequest<List<Seaside>>
    {
        public bool IsGuarded;

        public bool OffersUmbrellas;
    }
}
